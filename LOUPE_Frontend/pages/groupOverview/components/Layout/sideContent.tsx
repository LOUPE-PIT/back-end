import {Box} from "@chakra-ui/layout";
import React from "react";
import LogDataComponent from "../../../logpage/components/LogDataComponent";

export default function SideContent() {
    return (
        <>
            <Box
                bg="white"
                borderRadius="20px"
                margin="1rem"
                height="50%"
                display="flex"
            >
                <LogDataComponent/>
            </Box>
        </>
    );
}
