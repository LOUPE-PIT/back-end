import {Popover, PopoverBody, PopoverContent, PopoverTrigger} from "@chakra-ui/react";
import {Text} from "@chakra-ui/layout";
import React from "react";


export default function Participants()
{
    return(
        <Popover
        >
            <PopoverTrigger>
                <Text fontSize="24px" marginRight="1rem" cursor="pointer">
                    4/6 Participants
                </Text>
            </PopoverTrigger>
            <PopoverContent color="black" bg="white" border="none">
                <PopoverBody>
                    <Text fontWeight="bold" color="green">Active:</Text>
                    <Text color="green">Participant 1</Text>
                    <Text color="green">Participant 2</Text>
                    <Text color="green">Participant 3</Text>
                    <Text color="green">Participant 4</Text>
                    <Text fontWeight="bold" color="gray.400">Inactive:</Text>
                    <Text color="gray.400">Participant 5</Text>
                    <Text color="gray.400">Participant 6</Text>
                </PopoverBody>
            </PopoverContent>
        </Popover>
    )
}