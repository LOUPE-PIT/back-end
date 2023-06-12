import React, { useState, Component } from 'react'
import FeedbackService from '../../../server/api/feedbackdata/feedbackservice'
import { usefeedbackService } from '../../../server/api/feedbackdata/feedbackservice';
import { Box, Flex, Button, Textarea} from '@chakra-ui/react';
import { addFeedback } from '../../../server/api/feedbackdata/model/addFeedback';
import { Console } from 'console';


interface FeedbackProps {

}

const AddFeedback = () => {
    const feedbackService = usefeedbackService();
    const [textValue, setTextValue] = useState('');
    const feedbackInstance: addFeedback = {
        logId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
        userId: 'd35da748-460e-447b-8e87-6fcb05f8352a',
        date:  new Date().toLocaleString(),
        feedbackText: textValue
    }

    function Add() {
        
        if (feedbackService !== undefined) {
        feedbackService.postfeedback(feedbackInstance), [feedbackService];
        };
}
return (
    <Box>
        <Textarea placeholder='Here is a sample placeholder' value={textValue}
        onChange={(e) => setTextValue(e.target.value)} />
        <Flex justifyContent='flex-end'>
            <Button className='addBtn' onClick={() => Add()}>Add</Button>
        </Flex>
    </Box>
  )
}
export default AddFeedback
    