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

const SignalRConnection: FC<ConnectionProps> = ({ roomId, setTransformation}) => {
    const [connection, setConnection] = useState<HubConnection | null>(null);

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

                connection.on('ReceiveSynchronization', synchronizationMessage =>{
                    const synchronization: Synchronization = JSON.parse(synchronizationMessage);
                    
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
