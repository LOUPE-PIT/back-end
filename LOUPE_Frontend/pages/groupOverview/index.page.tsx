import React from 'react';
import "./code.css"
import {Box} from "@chakra-ui/layout";
import Header from "./components/Layout/header";
import Content from "./components/Layout/content";
import SideContent from "./components/Layout/sideContent";

export {Page}

function Page() {
    return (
        <Box
            display="flex"
            height="100vh"
            overflow="hidden"
        >
            <Box 
                width="70%" 
                flex="1"
            >
                <Box>
                    <Header />
                </Box>
                <Box 
                    flex="1">
                    <Content />
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
