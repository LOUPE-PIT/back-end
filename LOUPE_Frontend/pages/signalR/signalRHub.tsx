import React, { useEffect, FC, useState } from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Vector3 } from 'three';

interface ConnectionProps {
    roomId: string;
    setTransformation: Function;
    }

export interface Synchronization {
    NewPosition: Vector3;
    DegreesRotation: number;
    ObjectName: string;
}

const SignalRConnection: FC<ConnectionProps> = ({ roomId }: ConnectionProps, {setTransformation}) => {
    const [connection, setConnection] = useState<HubConnection | null>(null);

    useEffect(() => {
        const synchronization = {} as Synchronization
        synchronization.DegreesRotation = 1.234;
        synchronization.NewPosition = new Vector3(1.2, 2.5, 3.3);
        synchronization.ObjectName = "Schroef25";
        console.log(synchronization);
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

                connection.on('ReceiveSynchronization', synchronizationMessage =>{
                    const synchronization: Synchronization = JSON.parse(synchronizationMessage);
                    console.log(synchronization);
                    setTransformation(synchronization);
                });
            })
            .catch(e => console.log('Connection failed: ', e));

        }
    }, [connection]);

    return (
    <div>
    </div>
    );
};

export default SignalRConnection;
