import React, { FC, useEffect, useMemo, useState } from 'react';
import { useLogService } from '../../../server/api/logdata/logservice';
import { Log } from '../../../server/api/logdata/model/log';
import Logs from './LogsComponent';
import {
  Box
} from "@chakra-ui/layout";

interface LogComponentProps { }

const LogComponent: FC<LogComponentProps> = () => {
  const logService = useLogService();
  const [logs, setLogs] = useState<Log[]>([]);

  const memoizedLogService = useMemo(() => logService, [logService]);

  useEffect(() => {
    if (memoizedLogService !== undefined) {
      memoizedLogService.getLogs().then((result) => {
        setLogs(result);
      }).catch((error) => {
        console.error(error);
      });
    }
  }, [memoizedLogService]);

  return (
    <Box
      borderRadius="10px"
      width="100%"
    >
      <Logs logs={logs}></Logs>
    </Box>

  );
};

export default LogComponent;
