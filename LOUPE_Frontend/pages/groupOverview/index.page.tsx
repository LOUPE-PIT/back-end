import React from 'react';
import "./code.css"
import {Box} from "@chakra-ui/layout";
import Header from "./components/Layout/header";
import Content from "./components/Layout/content";

export {Page}

function Page() {
    return (
        <Box
            height="100vh"
            overflow="hidden"
        >
            <Header/>
            <Content />
            {/*<SideComponent />*/}
        </Box>
    )
}
