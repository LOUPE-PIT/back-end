import React, { FC } from 'react'
import { Log } from '../../../server/api/logdata/model/log';

interface LogProps {
    log: Log;
}
const LogComponent: FC<LogProps> = ({ log }: LogProps) => {
    return (
        <div className='logText'><p>{log.text}</p></div>
    );
}

export default LogComponent;