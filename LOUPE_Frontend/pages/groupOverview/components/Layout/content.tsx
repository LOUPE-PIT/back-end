import {Box, VStack, IconButton, Button, Input, Select} from "@chakra-ui/react";
import {AddIcon} from "@chakra-ui/icons";
import React, {useEffect, useState} from "react";
import Group from "../groupComponent/Group";
import axios from "axios";
import {Text} from "@chakra-ui/layout";
import CreateGroupForm from "../../Forms/CreateGroupForm";

interface GroupProps {
    selected: boolean;
    onClick?: () => void;
    id?: string;
    name: string;
    roomCode: string;
}

export default function Content() {
    const [selectedGroupIndex, setSelectedGroupIndex] = useState(-1);
    const [groups, setGroups] = useState<GroupProps[]>([]);
    const [isPopoverOpen, setPopoverOpen] = useState(false);

    useEffect(() => {
        fetchGroups();
    }, []);

    const fetchGroups = async () => {
        try {
            const response = await axios.get("http://localhost:5006/Grouping");
            console.log(response.data)
            setGroups(response.data);
        } catch (error) {
            console.log("Error fetching groups:", error);
        }
    };

    const handleGroupClick = (groupIndex: number) => {
        setSelectedGroupIndex(groupIndex);
    };

    const getUniqueGroupsByRoomCode = (): GroupProps[] => {
        const uniqueGroups: GroupProps[] = [];
        const roomCodes = new Set();

        groups.forEach((group) => {
            if (!roomCodes.has(group.roomCode)) {
                uniqueGroups.push(group);
                roomCodes.add(group.roomCode);
            }
        });

        return uniqueGroups;
    };
    const uniqueGroups = getUniqueGroupsByRoomCode();

    useEffect(() => {
        if (isPopoverOpen) {
            document.body.classList.add("blur");
        } else {
            document.body.classList.remove("blur");
        }
    }, [isPopoverOpen]);

    return (
        <Box position="relative">
            <Box
                bg="white"
                borderRadius="20px"
                margin="1rem"
                height="85.5vh"
                display="flex"
                overflowY="scroll"
                position="relative"
            >
                <VStack width="100%" spacing="4" mt={4}>
                    {uniqueGroups.map((group, index) => (
                        <Group
                            key={index}
                            selected={selectedGroupIndex === index}
                            onClick={() => handleGroupClick(index)}
                            id={group.id}
                            name="TestName"
                            roomCode={group.roomCode}
                        />
                    ))}
                </VStack>
            </Box>

            <Box
                position="absolute"
                bottom="1rem"
                left="2rem"
                zIndex={1}
                display="flex"
            >
                <IconButton
                    aria-label="Add Group"
                    icon={<AddIcon/>}
                    colorScheme="blue"
                    size="lg"
                    boxShadow="md"
                    onClick={() => setPopoverOpen(!isPopoverOpen)}
                />
            </Box>

            {isPopoverOpen && (
                <Box
                    position="fixed"
                    right="0"
                    top="0"
                    height="100vh"
                    width="25%"
                    bg="#1066A3"
                    zIndex={999}
                    transition="transform 0.3s ease-in-out"
                    transform="translateX(0%)"
                    padding="1rem"
                    overflowY="scroll"
                >
                    <Text
                        fontSize="24px"
                        fontWeight="bold"
                        color="white"
                        mb="2rem"
                    >
                        Maak hier een nieuwe groep aan
                    </Text>
                    <CreateGroupForm/>
                </Box>
            )}
        </Box>
    );
}
