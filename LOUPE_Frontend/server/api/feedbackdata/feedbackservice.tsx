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
            const result = await axios.get('https://localhost:7114/api/Feedback/All', { params: { userid: userid } })
            tempfeedbacks = result.data;

            await Promise.all(tempfeedbacks.map(async (item) => {
                const result2 = await axios.get('https://localhost:7211/Users/' + item.userId);
                console.log("rijst")
                console.log(result2.data.name)
                item.userName = result2.data.name;


                console.log("pasta")
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
            console.log("Create")
            console.log(feedbackViewmodel)
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