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
        userId: 'd35da748-460e-447b-8e87-6fcb05f8352a',
        date: new Date().toISOString(),
        feedbackText: textValue
    }

    function Add() {
        if (feedbackService !== undefined) {
            feedbackService.postfeedback(feedbackInstance), [feedbackService];
        }
        ;
    }

    return (
        <Box display="flex" alignItems="center">
            <Input placeholder="Type hier je feedback..." value={textValue}
                   onChange={(e) => setTextValue(e.target.value)}/>
            <Button className="addBtn" onClick={() => Add()}>Add</Button>
        </Box>
    )
}
export default AddFeedback
    