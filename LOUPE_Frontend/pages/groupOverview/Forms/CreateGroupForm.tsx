import { Button, Select, Flex } from '@chakra-ui/react';
import { AddIcon, CloseIcon } from '@chakra-ui/icons';
import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface User {
    userId: string;
    name: string;
    email: string;
    isStudent: boolean;
}

export default function CreateGroupForm() {
    const [users, setUsers] = useState<User[]>([]);
    const [inputFields, setInputFields] = useState<string[]>(['']);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await axios.get<User[]>('https://localhost:7211/users');
                setUsers(response.data);
            } catch (error) {
                console.error('Error fetching users:', error);
            }
        };

        fetchUsers();
    }, []);

    const handleAddField = () => {
        setInputFields([...inputFields, '']);
    };

    const handleInputChange = (index: number, value: string) => {
        const updatedFields = [...inputFields];
        updatedFields[index] = value;
        setInputFields(updatedFields);
    };

    const handleRemoveField = (index: number) => {
        const updatedFields = [...inputFields];
        updatedFields.splice(index, 1);
        setInputFields(updatedFields);
    };

    const handleFormSubmit = async () => {
        try {
            const payload = {
                userIds: inputFields.filter(Boolean),
            };

            await axios.post('http://localhost:5006/grouping', payload);
            console.log('Data submitted successfully!');
            window.location.reload();
        } catch (error) {
            console.error('Error submitting data:', error);
        }
    };

    return (
        <div>
            <form>
                {users.length > 0 &&
                    inputFields.map((input, index) => (
                        <Flex key={index} align="center" mb="1rem">
                            <Select
                                value={input}
                                onChange={(e) => handleInputChange(index, e.target.value)}
                                background={'rgba(255, 255, 255, 0.5)'}
                                color="black"
                                flex="1"
                                mr="1rem"
                            >
                                <option value="">Selecteer een student</option>
                                {users.map((user) => (
                                    <option key={user.userId} value={user.userId}>
                                        {user.name}
                                    </option>
                                ))}
                            </Select>
                            <Button
                                onClick={() => handleRemoveField(index)}
                                colorScheme="red"
                                size="sm"
                                zIndex="1"
                                display="flex"
                                alignItems="center"
                                justifyContent="center"
                                padding="0"
                            >
                                <CloseIcon />
                            </Button>

                        </Flex>
                    ))}
                <Button onClick={handleAddField} colorScheme="blue" leftIcon={<AddIcon />} mt="1rem">
                    Voeg nog een student toe
                </Button>
            </form>
            <Button onClick={handleFormSubmit} colorScheme="blue" leftIcon={<AddIcon />} mt="1rem">
                Submit
            </Button>
        </div>
    );
}
