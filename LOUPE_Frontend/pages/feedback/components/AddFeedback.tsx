import React, {useState, Component} from 'react'
import FeedbackService from '../../../server/api/feedbackdata/feedbackservice'
import {usefeedbackService} from '../../../server/api/feedbackdata/feedbackservice';
import {Box, Flex, Button, Textarea, Input} from '@chakra-ui/react';
import {addFeedback} from '../../../server/api/feedbackdata/model/addFeedback';


interface FeedbackProps {

}

const AddFeedback = () => {
    const feedbackService = usefeedbackService();
    const [textValue, setTextValue] = useState('');
    const feedbackInstance: addFeedback = {
        logId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
        userId: 'd7cf81dc-f665-496a-8a81-08db7095bd75',
        date: new Date().toISOString(),
        feedbackText: textValue
    }

    async function Add() {
        if (feedbackService !== undefined) {
           await feedbackService.postfeedback(feedbackInstance), [feedbackService];
        }
        window.location.reload();
        
    }

    return (
        <Box display="flex" margin="1.5rem">
            <Input color="black" placeholder="Type hier je feedback..." value={textValue}
                   onChange={(e) => setTextValue(e.target.value)}/>
            <Button bg="#F0615E" color="white" className="addBtn" onClick={() => Add()}>Add</Button>
        </Box>
    )
}
export default AddFeedback
    