import React, { FC, useEffect, useState } from 'react';
import { useLogService } from '../../../server/api/logdata/logservice';
import { Log } from '../../../server/api/logdata/model/log';
import Logs from './LogsComponent';

interface LogComponentProps {}

const LogComponent: FC<LogComponentProps> = () => {
  const logService = useLogService();
  const [logs, setLogs] = useState<Log[]>([]);

  useEffect(() => {
    if (logService !== undefined) {
      logService.getLogs().then((result) => {
        setLogs(result);
      });
    }
  }, [logService]);

  return <Logs logs={logs}></Logs>;
};

export default LogComponent;
