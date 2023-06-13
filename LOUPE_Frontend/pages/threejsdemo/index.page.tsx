import React, { useEffect } from 'react'
import './code.css'
import { useState } from "react";
import Header from "./Layout/header";
import Content from "./Layout/content";
import Connection from "../signalR/signalRHub"
import { Synchronization } from "../signalR/signalRHub"
import SideContent from '../groupOverview/components/Layout/sideContent';
import { Box } from '@chakra-ui/react';

export { Page }

function Page() {
    const [transformation, setTransformation] = useState<Synchronization>();

    return (
        <Box
            display="flex"
            height="100vh"
            overflow="hidden"
        >
            <Box
                width="100%"
                flex="1"
            >
                <Box><Connection roomId="3fa85f64-5717-4562-b3fc-2c963f66afa6" setTransformation={setTransformation} /></Box>
                <Box><Header /></Box>
                <Box
                    flex="1">
                    <Content transformation={transformation} />
                </Box>
            </Box>
            <Box
                width="30%"
            >
                <SideContent />
            </Box>
        </Box>
    )
}