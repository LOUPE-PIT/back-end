import { Box, Text } from "@chakra-ui/layout";
import { FaUsers } from 'react-icons/fa';
import React from "react";
import { Avatar, AvatarBadge, AvatarGroup, Wrap, WrapItem } from '@chakra-ui/react'

export default function Header() {
    return (
        <Box
            bg="#1066A3"
            borderRadius="20px"
            margin="1rem 0"
            width="100%"
            height="8vh"
            display="flex"
            alignItems="center"
            pl={8}
        >
            <FaUsers size={24} color="white" />
            <Text fontSize="24px" fontWeight="bold" color="white" pl={3}>
                Opdracht
            </Text>
            <Wrap style={{width:'87%'}}>
                <WrapItem>
                    <Avatar name='Dan Abrahmov' src='https://bit.ly/dan-abramov' />
                </WrapItem>
                <WrapItem>
                    <Avatar name='Kola Tioluwani' src='https://bit.ly/tioluwani-kolawole' />
                </WrapItem>
                <WrapItem>
                    <Avatar name='Kent Dodds' src='https://bit.ly/kent-c-dodds' />
                </WrapItem>
                <WrapItem>
                    <Avatar name='Ryan Florence' src='https://bit.ly/ryan-florence' />
                </WrapItem>
                <WrapItem>
                    <Avatar name='Prosper Otemuyiwa' src='https://bit.ly/prosper-baba' />
                </WrapItem>
                <WrapItem>
                    <Avatar name='Segun Adebayo' src='https://bit.ly/sage-adebayo' />
                </WrapItem>
            </Wrap>
        </Box>
    )
}