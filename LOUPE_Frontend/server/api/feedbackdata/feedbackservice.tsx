import React, { FC, createContext, useState } from 'react';
import { feedback } from './model/feedback';
import ProvidedServices from '../../contextmanager/ProvidedServices';
import Contextualizer from '../../contextmanager/Contextualizer';
import axios from 'axios';
import { addFeedback } from './model/addFeedback';
import { response } from 'express';

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
            let UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            console.log(UserId);
            const result = await axios.get('https://localhost:7114/api/Feedback/GetByLogId', { params: {UserId}})
            console.log(result);
            tempfeedbacks = result.data;

            await Promise.all(tempfeedbacks.map(async (item) => {
                const result2 = await axios.get('https://localhost:7211/Users/' + item.userId);

                console.log(result2.data.name)
                item.userName = result2.data.name;

                console.log(item.userName)
            }));
            console.log(tempfeedbacks)
            return tempfeedbacks;
        },

        async postfeedback(addFeedback: addFeedback) {

            const feedbackViewmodel = {
                    logId: addFeedback.logId,
                    userId: addFeedback.userId,
                    date: addFeedback.date,
                    feedbackText: addFeedback.feedbackText
            }
            await axios.post('https://localhost:7114/api/Feedback', feedbackViewmodel)
        },




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