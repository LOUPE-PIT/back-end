import React, { FC, createContext, useState } from 'react';
import { feedback } from './model/feedback';
import ProvidedServices from '../../contextmanager/ProvidedServices';
import Contextualizer from '../../contextmanager/Contextualizer';
import axios from 'axios';
import { addFeedback } from './model/addFeedback';

export interface IfeedbackService {
    getfeedbacks(): Promise<feedback[]>,
    postfeedback(feedbackInstance: addFeedback): Promise<any>
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
            const result = await axios.get('https://localhost:7114/api/Feedback/All',{ params: { userid: userid } })
            tempfeedbacks = result.data;
            return tempfeedbacks;
        },

        async postfeedback(addFeedback: addFeedback) {
            console.log(addFeedback);
            const result = await axios.post('https://localhost:7114/api/Feedback/Create',{ params: { addFeedback: addFeedback } })

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