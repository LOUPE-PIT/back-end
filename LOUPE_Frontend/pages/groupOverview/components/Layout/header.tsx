import {Box, Text} from "@chakra-ui/layout";
import {FaUsers} from 'react-icons/fa';
import React from "react";

export default function Header() {
    return (
        <Box
            bg="#1066A3"
            borderRadius="20px"
            margin="1rem"
            height="8vh"
            display="flex"
            alignItems="center"
            pl={8}
        >
            <FaUsers size={24} color="white"/>
            <Text fontSize="24px" fontWeight="bold" color="white" pl={3}>
                Groepen
            </Text>
        </Box>
    )
}