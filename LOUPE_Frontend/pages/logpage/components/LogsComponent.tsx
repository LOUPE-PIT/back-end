import React, { FC } from 'react'
import { Log } from '../../../server/api/logdata/model/log';
import LogComponent from './LogComponent';

interface LogsProps {
    logs: Log[];
}

const LogsComponent: FC<LogsProps> = ({ logs }: LogsProps) => {
    console.log(logs);
    return (<>
        {logs.map(log => {
            return (<LogComponent log={log} />)
        })}
    </>);
}

export default LogsComponent;