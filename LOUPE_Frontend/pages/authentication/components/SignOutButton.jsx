import React from 'react';
import { Button, ButtonGroup } from '@chakra-ui/react';
import { useMsal } from '@azure/msal-react';

export const SignOutButton = () => {
    const { instance } = useMsal();

    const handleSignOut = () => {
        instance.logoutRedirect();
    }
    return (
        <Button color="inherit" onClick={handleSignOut}>Sign out</Button>
    )
};