import {Box} from "@chakra-ui/layout";
import React from "react";
import LogDataComponent from "../../../logpage/components/LogDataComponent";
import FeedbackComponent from "../../../feedback/components/FeedbackComponent";

export default function SideContent() {
    return (
        <>
            <Box
                borderRadius="20px"
                margin="1rem"
                height="47vh"
                display="flex"
            >
                <LogDataComponent/>
            </Box>
            <Box
                borderRadius="20px"
                margin="1rem"
                height="47vh"
                display="flex"
            >
                <FeedbackComponent />
            </Box>
        </>
    );
}
