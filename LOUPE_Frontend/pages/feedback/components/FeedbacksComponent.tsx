import React, {Component, FC} from 'react'
import {feedback} from '../../../server/api/feedbackdata/model/feedback';
import dayjs from 'dayjs';
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
    Spacer,
    HStack
} from '@chakra-ui/react';
import AddFeedback from './AddFeedback';

interface FeedbackProps {
    feedbacks: feedback[];
}


const FeedbacksComponent: FC<FeedbackProps> = ({feedbacks}: FeedbackProps) => {
    return (
        <>
            <Card
                borderRadius="25px"
                width="100%"
                justifyContent="space-between"
                color="black"
                bg="white"
                className='feedbackCard'
             
                boxShadow='none'
            >
                <CardHeader textAlign="center">
                    <Heading size='lg'>Feedback</Heading>
                </CardHeader>
                <CardBody
                    width="100%"
                    overflowY='scroll'
                >
                    <Stack divider={<StackDivider/>}>
                        <div className='feedbackDiv'>
                            {feedbacks.length === 0 ?(<div>Selecteer een log.</div>):(feedbacks.map(feedback => {
                                const userName = feedback.userName || "guest";
                                return (
                                    <Box className='feedback' key={feedback.feedbackId} mb={10}>
                                        <HStack align='center' spacing='24px'>
                                            <Avatar name={feedback.userName} bg='red.500' />
                                  
                                        <Text>{userName}</Text>
           
                                            <Text>{dayjs(feedback.date).format("MM/DD/YYYY")}</Text>
                                        </HStack>
                                        <Text pt='2' fontSize='sm'>
                                            {feedback.feedbackText}
                                        </Text>
                                    </Box>
                                )
                            }))}
                        </div>
                    </Stack>
                </CardBody>
                <AddFeedback/>
            </Card>
        </>
    );
}

export default FeedbacksComponent;