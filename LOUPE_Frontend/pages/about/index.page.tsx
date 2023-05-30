import React from 'react';
import './code.css';
import {Box} from "@chakra-ui/layout";

export { Page }

function Page() {
  return (
    <>
      <h1>About</h1>
      <Box>
        Example of using <code>vite-plugin-ssr</code>.
      </Box>
    </>
  )
}
