import {Box} from "@chakra-ui/layout";
import React from "react";
import Duck from "../../../3Dobjectcomponents/duck";
import {Canvas, useThree} from "@react-three/fiber";
import {OrbitControls} from "@react-three/drei";

function Controls() {
    const {
        camera,
        gl: { domElement },
    } = useThree();

    return <OrbitControls args={[camera, domElement]} minDistance={0} maxDistance={10} />;
}

export default function Content() {
    return (
        <Box
            bg="white"
            borderRadius="20px"
            margin="1rem"
            width="70%"
            height="85.5vh"
            display="flex"
            justifyContent="center"
            alignItems="center"
            overflow="hidden"
        >
            <Canvas style={{ width: '100%', height: '100%' }}>
                <ambientLight />
                <pointLight position={[5, 5, 5]} intensity={1} />
                <pointLight position={[-3, -3, 2]} intensity={1} />
                <Controls />
                <Duck position={[0, -1, -3]} />
            </Canvas>
        </Box>
    );
}

