import {Box, Text} from "@chakra-ui/layout";
import {FaUsers} from 'react-icons/fa';
import React from "react";
interface PageProps{
    roomCode: string
}
export default function Header({roomCode}:PageProps) {
    return (
        <Box
            bg="#1066A3"
            borderRadius="20px"
            margin="1rem"
            width="70%"
            height="8vh"
            display="flex"
            alignItems="center"
            pl={8}
        >
            <FaUsers size={24} color="white"/>
            <Text fontSize="24px" fontWeight="bold" color="white" pl={3}>
                Opdracht - {roomCode}
            </Text>
        </Box>
    )
}