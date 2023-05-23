import { FC } from "react"
import LogService from "./api/logdata/logservice"
import FeedbackService from "./api/feedbackdata/feedbackservice";
import React from "react";

type GlobalServicesProps = {
    children: React.ReactNode;
}

const GlobalServices: FC<GlobalServicesProps> = ({ children }: GlobalServicesProps) => {
    return (
        <>
            <FeedbackService>
                <LogService>
                    {children}
                </LogService>
            </FeedbackService>
        </>
    )
}

export default GlobalServices;