import React, { FC } from 'react'
import { Log } from '../../../server/api/logdata/model/log';
import { Box } from '@chakra-ui/react';

interface LogProps {
    log: Log;
}
const LogComponent: FC<LogProps> = ({ log }: LogProps) => {
    const setLogId = (id: string) => {
        sessionStorage.setItem('logId', id);
        document.cookie = `logId=${id}; expires=Fri, 31 Dec 9999 23:59:59 GMT`;
        window.location.reload();
    };
    
    return (
        <div onClick={() => setLogId(log.id)}>
            <Box
                borderRadius="10px"
                width="100%"
                backgroundColor="#1066A3"
                color="white"
                margin="10px 0"
                padding="1rem"
                cursor="pointer"
            >
                <div><p>{log.text}</p></div>
            </Box>
        </div>

    );
}

export default LogComponent;