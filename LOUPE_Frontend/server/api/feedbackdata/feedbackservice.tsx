import React, { FC, createContext, useState } from 'react';
import { feedback } from './model/feedback';
import ProvidedServices from '../../contextmanager/ProvidedServices';
import Contextualizer from '../../contextmanager/Contextualizer';
import axios from 'axios';

export interface IfeedbackService {
    getfeedbacks(): Promise<feedback[]>,
    postfeedback(): Promise<any>
}

 
type feedbackServiceProps = {
    children: React.ReactNode
}

const feedbackServiceContext = Contextualizer.createContext(ProvidedServices.FeedbackService);
export const usefeedbackService = () => Contextualizer.use<IfeedbackService>(ProvidedServices.FeedbackService);

const FeedbackService: FC<feedbackServiceProps> = ({ children }: any) => {

    const FeedbacksService = {
        async getfeedbacks(userid: string): Promise<feedback[]> {
            let tempfeedbacks: feedback[];
            //const result = await axios.get('https://localhost:7123/feedback/GetByUserId',{ params: { userid: userid } })
            const result = await axios.get('https://aaaaaaaa.free.beeceptor.com/feedback/GetByUserId',{ params: { userid: userid } })
            tempfeedbacks = result.data;
            return tempfeedbacks;
        },

        async postfeedback(text: string) {

            //const result = await axios.get('https://localhost:7123/feedback/GetByUserId',{ params: { userid: userid } })
            const result = await axios.post('https://aaaaa.free.beeceptor.com/feedback/create',{ params: { text: text } })

        }
    }

    return (
        <>
            <feedbackServiceContext.Provider value={FeedbacksService}>
                {children}
            </feedbackServiceContext.Provider>
        </>
    )
}

export default FeedbackService;