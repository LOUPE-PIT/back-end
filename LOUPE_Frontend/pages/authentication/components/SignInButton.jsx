import React from 'react';
import { Button, ButtonGroup } from '@chakra-ui/react';
import { useMsal } from "@azure/msal-react";


export const SignInButton = () => {
    const { instance } = useMsal();

    const handleSignIn = () => {
        instance.loginRedirect({
            scopes: ['user.read']
        });
    }
    return (
        <Button color="inherit" onClick={handleSignIn}>Sign in</Button>
    )   
};