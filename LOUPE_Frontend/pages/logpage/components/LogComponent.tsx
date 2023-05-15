import React, { FC } from 'react'
import { Log } from '../../../server/api/logdata/model/log';
import { Box } from '@chakra-ui/react';

interface LogProps {
    log: Log;
}
const LogComponent: FC<LogProps> = ({ log }: LogProps) => {
    return (
        <Box
            borderRadius="10px"
            width="100%"
            backgroundColor="#1066A3"
            color="white"
            margin="10px 0"
            padding="1rem"
            cursor="pointer"
        >
            <div className='logText'><p>{log.text}</p></div>
        </Box>
    );
}

export default LogComponent;