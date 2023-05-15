import React, { useState, Component } from 'react'
import FeedbackService from '../../../server/api/feedbackdata/feedbackservice'
import { usefeedbackService } from '../../../server/api/feedbackdata/feedbackservice';
import { Box, Flex, Button, Textarea} from '@chakra-ui/react';
import { Console } from 'console';


interface FeedbackProps {

}

const AddFeedback = () => {
    const feedbackService = usefeedbackService();

    function Add(text: string) {
        console.log(text)
        if (feedbackService !== undefined) {
        feedbackService.postfeedback(), [feedbackService];
        };
}
return (
    <Box>
        <Textarea placeholder='Here is a sample placeholder' />
        <Flex justifyContent='flex-end'>
            <Button className='addBtn' onClick={() => Add('lalaal')}>Add</Button>
        </Flex>
    </Box>
  )
}
export default AddFeedback
    