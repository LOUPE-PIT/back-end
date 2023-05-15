import {Box} from "@chakra-ui/layout";
import React, {useEffect, useState} from "react";
import Group from "../groupComponent/Group";
import {VStack} from "@chakra-ui/react";
import axios from "axios";

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

    useEffect(() => {
        fetchGroups();
    }, []);

    const fetchGroups = async () => {
        try {
            const response = await axios.get('https://localhost:7232/Grouping');
            setGroups(response.data);
        } catch (error) {
            console.log('Error fetching groups:', error);
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

    return (
        <>
            <Box
                bg="white"
                borderRadius="20px"
                margin="1rem"
                height="85.5vh"
                display="flex"
                overflowY="scroll"
            >
                <VStack width="100%" spacing="4" mt={4}>
                    {uniqueGroups.map((group, index) => (
                        <Group
                            key={index}
                            selected={selectedGroupIndex === index}
                            onClick={() => handleGroupClick(index)}
                            name="TestName"
                            roomCode={group.roomCode}
                        />
                    ))}
                </VStack>
            </Box>
        </>
    );
}
