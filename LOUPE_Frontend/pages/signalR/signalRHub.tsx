import React, { useEffect, FC, useState } from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Vector3 } from 'three';

interface ConnectionProps {
    roomId: string;
}

interface Synchronization {
    NewPosition: Vector3;
    DegreesRotation: number;
    ObjectName: string;
}

const SignalRConnection: FC<ConnectionProps> = ({ roomId }: ConnectionProps) => {
    const [connection, setConnection] = useState<HubConnection | null>(null);
    const [synchronization, setSynchronization] = useState<Synchronization | null>(null);

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7241/hubs/sync')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
            .then(result => {
                connection.invoke("JoinRoom", roomId);

                const synchronization = {} as Synchronization
                synchronization.DegreesRotation = 1.234;
                synchronization.NewPosition = new Vector3(1.2, 2.5, 3.3);
                synchronization.ObjectName = "Schroef25";
                
                connection.invoke("ReceiveSynchronization", synchronization, roomId)

                connection.on('ReceiveSynchronization', synchronizationMessage =>{
                    console.log(synchronizationMessage);
                    const synchronization: Synchronization = JSON.parse(synchronizationMessage);
                    setSynchronization(synchronization);
                });
            })
            .catch(e => console.log('Connection failed: ', e));

        }
    }, [connection]);

    const joinRoom = async () => {
        connection!.invoke("JoinRoom", roomId);
    };

    return (
    <div>
        {synchronization?.ObjectName}
        {synchronization?.NewPosition.x} {synchronization?.NewPosition.y} {synchronization?.NewPosition.z}
        {synchronization?.DegreesRotation}
    </div>
    );
};

export default SignalRConnection;
