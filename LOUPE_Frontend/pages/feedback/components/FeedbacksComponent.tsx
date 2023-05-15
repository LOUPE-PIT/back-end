import React, { Component, FC } from 'react'
import { feedback } from '../../../server/api/feedbackdata/model/feedback';
import { Avatar, Card, CardHeader, CardBody, Heading, Stack, Box, Text, StackDivider, Flex, Button, Textarea, Spacer } from '@chakra-ui/react';
import AddFeedback from './AddFeedback';

interface FeedbackProps {
  
    feedbacks: feedback[];

}

var options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };

const FeedbacksComponent: FC<FeedbackProps> = ({ feedbacks }: FeedbackProps) => {
    console.log(feedbacks);

    if(feedbacks.length > 0){
      console.log("test");
      console.log(feedbacks[0].date);
    }
   
    return (

<>

     <Card className='feedbackCard' bg='gray.50' >
        <CardHeader textAlign="center">
          <Heading size='lg'>Feedback</Heading>
        </CardHeader>


        <CardBody>
        <Stack divider={<StackDivider />} spacing='2'>
          <div className='feedbackDiv'>
            {feedbacks.map(feedback => {
                return (
                    <Box className='feedback' key={feedback.feedbackId}>
                    <Flex align='center'>
                    <Avatar name={feedback.userId}  bg='red.500'/>
                      <Spacer />
                      <Text pl='5'>{feedback.userId}</Text>
                      <Spacer />
                      <Text pl='20'>{feedback.date}</Text>
                    </Flex>
                    <Text pt='2' fontSize='sm'>
                      {feedback.feedbackText}
                    </Text>
                  </Box>
            )})}
          </div>
        <AddFeedback/>
          </Stack>
        </CardBody>
      </Card>

    </>

    );
}

export default FeedbacksComponent;