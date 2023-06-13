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

     <Card
         borderRadius="25px"
         width="100%"
         alignItems="center"
         justifyContent="space-between"
         padding="0 1rem 1rem 1rem"
         color="black"
         backgroundColor="white"
         className='feedbackCard' 
         bg='gray.50'
     >
        <CardHeader textAlign="center">
          <Heading className="title">Feedback</Heading>
        </CardHeader>


        <CardBody 
        width="100%"
        >
        <Stack divider={<StackDivider />}>
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