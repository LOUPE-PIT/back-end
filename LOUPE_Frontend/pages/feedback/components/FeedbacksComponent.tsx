import React, {Component, FC} from 'react'
import {feedback} from '../../../server/api/feedbackdata/model/feedback';
import {
    Avatar,
    Card,
    CardHeader,
    CardBody,
    Heading,
    Stack,
    Box,
    Text,
    StackDivider,
    Flex,
    Button,
    Textarea,
    Spacer
} from '@chakra-ui/react';
import AddFeedback from './AddFeedback';

interface FeedbackProps {
    feedbacks: feedback[];
}

var options = {weekday: 'long', year: 'numeric', month: 'long', day: 'numeric'};

const FeedbacksComponent: FC<FeedbackProps> = ({feedbacks}: FeedbackProps) => {
    return (
        <>

            <Card
                borderRadius="25px"
                width="100%"
                alignItems="center"
                justifyContent="space-between"
                color="black"
                backgroundColor="white"
                className='feedbackCard'
                bg='gray.50'
                boxShadow='none'
            >
                <CardHeader textAlign="center">
                    <Heading size='lg'>Feedback</Heading>
                </CardHeader>
                <CardBody
                    width="100%"
                >
                    <Stack divider={<StackDivider/>}>
                        <div className='feedbackDiv'>
                            {feedbacks.map(feedback => {
                                return (
                                    <Box className='feedback' key={feedback.feedbackId}>
                                        <Flex align='center'>
                                            <Avatar name={feedback.userName} bg='red.500'/>
                                            <Spacer/>
                                            <Text pl='5'>{feedback.userName}</Text>
                                            <Spacer/>
                                            <Text pl='20'>{feedback.date}</Text>
                                        </Flex>
                                        <Text pt='2' fontSize='sm'>
                                            {feedback.feedbackText}
                                        </Text>
                                    </Box>
                                )
                            })}
                        </div>
                        <AddFeedback/>
                    </Stack>
                </CardBody>
            </Card>
        </>
    );
}

export default FeedbacksComponent;