import {Box, Text} from "@chakra-ui/layout";
import React from "react";

export default function Header()
{
    return(
        <Box
            bg="#1066A3"
            borderRadius="20px"
            margin="1rem"
            width="70%"
            height="8vh"
            display="flex"
            alignItems="center"
        >
            <Text 
                color="white" 
                fontSize="1.5em"
                pl={8}
            >
                Groepen
            </Text>
        </Box>
    )
}