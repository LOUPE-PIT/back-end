import React, { Component, FC } from 'react'
import { Log } from '../../../server/api/logdata/model/log';

interface LogProps {
    logs: Log[];
}

const LogsComponent: FC<LogProps> = ({ logs }: LogProps) => {
    console.log(logs);
    return (<>
        <table>
            <thead>
                <th>id</th>
                <th>userid</th>
                <th>groupid</th>
                <th>text</th>
            </thead>
            <tbody>
                {logs.map(log => {
                    return (<tr key={log.id}>
                        <td>{log.id}</td>
                        <td>{log.userid}</td>
                        <td>{log.groupid}</td>
                        <td>{log.text}</td>
                    </tr>)
                })}
            </tbody>
        </table>
    </>);
}

export default LogsComponent;