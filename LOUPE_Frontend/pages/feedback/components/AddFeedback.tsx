import React, {useState, Component} from 'react'
import FeedbackService from '../../../server/api/feedbackdata/feedbackservice'
import {usefeedbackService} from '../../../server/api/feedbackdata/feedbackservice';
import {Box, Flex, Button, Textarea, Input, Spacer} from '@chakra-ui/react';
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
            if (textValue.trim() === ''){
           await feedbackService.postfeedback(feedbackInstance), [feedbackService];
        }}
        window.location.reload();
        
    }

    return (
        <Box margin="1.5rem">
            <form onSubmit={Add}>
                <Flex>
                    <Input color="black" placeholder="Type hier je feedback..." value={textValue} required
                        onChange={(e) => setTextValue(e.target.value)}/>
                    <Button type='submit' bg="#F0615E" color="white" className="addBtn">Add</Button>
                </Flex>
            </form>

        </Box>
    )
}
export default AddFeedback
    