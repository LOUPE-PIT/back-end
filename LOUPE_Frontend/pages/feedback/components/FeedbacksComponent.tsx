import React, { Component, FC } from 'react'
import { feedback } from '../../../server/api/feedbackdata/model/feedback';
import { Avatar, Card, CardHeader, CardBody, Heading, Stack, Box, Text, StackDivider, Flex, Button, Textarea, Spacer } from '@chakra-ui/react';
import AddFeedback from './AddFeedback';

interface FeedbackProps {
    feedbacks: feedback[];
}

const FeedbacksComponent: FC<FeedbackProps> = ({ feedbacks }: FeedbackProps) => {
    console.log(feedbacks);
    return (

<>

     <Card className='feedbackCard' bg='gray.50'  maxW='30%' >
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
                    <Avatar name={feedback.userid}  bg='red.500'/>
                      <Spacer />
                      <Text pl='5'>{feedback.userid} </Text>
                      <Spacer />
                      <Text pl='20'>{feedback.timestamp.toString()}</Text>
                    </Flex>
                    <Text pt='2' fontSize='sm'>
                      {feedback.text}
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