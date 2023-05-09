import {ArrowForwardIcon} from "@chakra-ui/icons";
import React, {useState} from "react";
import {Button, Flex} from "@chakra-ui/react";
import {Box, Text} from "@chakra-ui/layout";
import Participants from "./participants";

interface GroupProps {
    selected: boolean;
    onClick?: () => void;
    id?: string;
    name: string;
    roomCode?: string;
}


export default function Group({selected, onClick, id, name, roomCode}: GroupProps)
{
    const [isClicked, setIsClicked] = useState(false);

    const handleClick = () => {
        setIsClicked(!isClicked);
        if (onClick) {
            onClick();
        }
    };
    
    return(
        <Box
            bg={selected ? "#F0615E" : "#1066A3"}
            borderRadius="10px"
            width="98%"
            height="12vh"
            display="flex"
            alignItems="center"
            justifyContent="space-between"
            padding="1rem"
            color="white"
            cursor="pointer"
            onClick={handleClick}
        >
            <Text fontSize="24px" fontWeight="bold">
                {name}
            </Text>
            <Flex alignItems="center">
               <Participants/>
                <Text fontSize="24px" marginRight="1rem">
                    6/6 Completed Steps
                </Text>
                <Text fontSize="24px" marginRight="1rem">
                    Room Code: {roomCode}
                </Text>
                <Button
                    leftIcon={
                        <ArrowForwardIcon
                            color="white"
                            boxSize={7}
                        />
                    }
                    variant="ghost"
                    aria-label="Settings"
                    _hover={{ bg: 'transparent' }}
                />
            </Flex>
        </Box>
    )
}