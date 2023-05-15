import React from 'react';
import './code.css';
import LogData from './components/LogDataComponent';
import { Box, Text } from "@chakra-ui/layout";

export { Page }

function Page() {
  return (
    <Box
      borderRadius="25px"
      width="30%"
      alignItems="center"
      justifyContent="space-between"
      padding="1rem"
      color="black"
      backgroundColor="white"
    >
      <div>
        <h1 className='title'>Geschiedenis</h1>
        <LogData />
      </div>
    </Box>
  )
}
