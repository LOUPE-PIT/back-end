import { FC } from "react"
import LogService from "./api/logdata/logservice"
import React from "react";

type GlobalServicesProps = {
    children: React.ReactNode;
}

const GlobalServices: FC<GlobalServicesProps> = ({ children }: GlobalServicesProps) => {
    return (
        <>
            <LogService>
                {children}
            </LogService>
        </>
    )
}

export default GlobalServices;