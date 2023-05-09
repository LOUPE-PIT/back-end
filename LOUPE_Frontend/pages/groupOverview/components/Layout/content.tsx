import {Box} from "@chakra-ui/layout";
import React, {useState} from "react";
import Group from "../groupComponent/Group";
import {VStack} from "@chakra-ui/react";


export default function Content() {
    const [selectedGroupIndex, setSelectedGroupIndex] = useState(-1);

    const handleGroupClick = (groupIndex : number) => {
        setSelectedGroupIndex(groupIndex);
    };
    
    //Get the groups
    
    return (
        <>
            <Box 
                bg="white" 
                borderRadius="20px"
                margin="1rem" 
                width="70%" 
                height="85.5vh" 
                display="flex"
                overflowY="scroll"
            >
                <VStack 
                    width="100%"
                    spacing="4"
                    mt={4}
                >
                    <Group
                        selected={selectedGroupIndex === 0}
                        onClick={() => handleGroupClick(0)}
                        name="Groep A"
                        roomCode="XXXXXX"
                    />
                    <Group
                        selected={selectedGroupIndex === 1}
                        onClick={() => handleGroupClick(1)}
                        name="Groep B"
                        roomCode="HEHEHE"
                    />
                    <Group
                        selected={selectedGroupIndex === 2}
                        onClick={() => handleGroupClick(2)}
                        name="Groep C"
                        roomCode="123456"
                    />
                </VStack>
            </Box>
        </>
    )
}