import {Popover, PopoverBody, PopoverContent, PopoverTrigger} from "@chakra-ui/react";
import {Text} from "@chakra-ui/layout";
import {useEffect, useState} from 'react';
import React from "react";
import axios from "axios";

interface Participant {
    userId: string;
}

interface ParticipantsProps {
    roomCode: string;
}

export default function Participants({roomCode}: ParticipantsProps) {
    const [participants, setParticipants] = useState<string[]>([]);

    useEffect(() => {
        fetchParticipants();
    }, [roomCode]);

    const fetchParticipants = async () => {
        try {
            const response = await axios.get(`https://localhost:7232/Grouping/roomCode?roomCode=${roomCode}`);
            setParticipants(response.data.map((participant: Participant) => participant.userId));
        } catch (error) {
            console.log('Error fetching participants:', error);
        }
    };
        return (
            <Popover>
                <PopoverTrigger>
                    <Text fontSize="24px" marginRight="1rem" cursor="pointer">
                        {participants.length}/6 Participants
                    </Text>
                </PopoverTrigger>
                <PopoverContent color="black" bg="white" border="none">
                    <PopoverBody>
                        <Text fontWeight="bold" color="green">
                            Active:
                        </Text>
                        {participants.slice(0, 4).map((participant, index) => (
                            <Text key={index} color="green">
                                {participant}
                            </Text>
                        ))}
                        <Text fontWeight="bold" color="gray.400">
                            Inactive:
                        </Text>
                        {participants.slice(4).map((participant, index) => (
                            <Text key={index} color="gray.400">
                                {participant}
                            </Text>
                        ))}
                    </PopoverBody>
                </PopoverContent>
            </Popover>
        )
    }