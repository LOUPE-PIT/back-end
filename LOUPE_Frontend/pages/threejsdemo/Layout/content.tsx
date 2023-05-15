import {Box} from "@chakra-ui/layout";
import React from "react";
import {Canvas, useThree} from "@react-three/fiber";
import Duck from "../../../3Dobjectcomponents/duck";
import {OrbitControls} from "@react-three/drei";

function Controls() {
    const {
        camera,
        gl: {domElement},
    } = useThree();

    return <OrbitControls args={[camera, domElement]}/>;
}

export default function Content() {
    return (
        <>
            <Box
                bg="white"
                borderRadius="20px"
                margin="1rem"
                width="70%"
                height="85.5vh"
                display="flex"
            >
                <Canvas style={{
                    position: 'absolute',
                    top: 0,
                    left: 0,
                    width: '70%',
                    height: '100%',
                }}>
                    <ambientLight />
                    <pointLight position={[5, 5, 5]} intensity={1} />
                    <pointLight position={[-3, -3, 2]} intensity={1} />
                    <Controls />
                    <Duck position={[0, 0, 0]} />
                </Canvas>
            </Box>
        </>
    );
}
