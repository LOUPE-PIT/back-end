import React, { useEffect, FC, useState } from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

interface ConnectionProps {
    roomId: string
}

const SignalRConnection:FC<ConnectionProps> = ({ roomId }:ConnectionProps) => {
    const [connection, setConnection] = useState<HubConnection | null>(null);

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7241/hubs/sync')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
        return ()=>leaveRoom();
    }, []); 

    useEffect(() => {
        if(connection)
        {
            joinRoom();
        }
    }, [connection]);

    const joinRoom = async () => {
        connection!.start()
            .then(result => {
                console.log('Connected!');

                connection!.invoke("JoinRoom", roomId);
            })
            .catch(e => console.log('Connection failed: ', e));
    };

    const leaveRoom = () => {
        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Leaving!');
    
                    connection.invoke("LeaveRoom", roomId);
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    };

    return <div>hihihiha</div>
};

export default SignalRConnection;