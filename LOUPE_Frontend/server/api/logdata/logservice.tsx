import React, { FC, createContext, useState } from 'react';
import { Log } from './model/log';
import ProvidedServices from '../../contextmanager/ProvidedServices';
import Contextualizer from '../../contextmanager/Contextualizer';
import axios from 'axios';

export interface ILogService {
    getLogs(): Promise<Log[]>
}

type LogServiceProps = {
    children: React.ReactNode
}

const LogServiceContext = Contextualizer.createContext(ProvidedServices.LogService);
export const useLogService = () => Contextualizer.use<ILogService>(ProvidedServices.LogService);

const LogService: FC<LogServiceProps> = ({ children }: any) => {

    const logsService = {
        async getLogs(): Promise<Log[]> {
            let templogs: Log[];
            const result = await axios.get('https://localhost:7123/Log/All')
            templogs = result.data;
            return templogs;
        }
    }

    return (
        <>
            <LogServiceContext.Provider value={logsService}>
                {children}
            </LogServiceContext.Provider>
        </>
    )
}

export default LogService;