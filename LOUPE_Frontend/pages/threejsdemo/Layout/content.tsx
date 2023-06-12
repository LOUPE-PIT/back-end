import { Box } from "@chakra-ui/layout";
import React, { useEffect, useState } from "react";
import Duck from "../../../3Dobjectcomponents/duck";
import { Redbutton } from "../../../3Dobjectcomponents/redbutton";
import { Canvas, context, useThree } from "@react-three/fiber";
import { OrbitControls } from "@react-three/drei";
import { Synchronization } from "../../signalR/signalRHub"
import * as THREE from 'three';
import { delay } from "framer-motion";

const Content = ({ transformation }: { transformation: Synchronization }) => {
    const [scene] = useState<THREE.Scene>(new THREE.Scene());
    const [rendererRef, setRender] = useState<THREE.WebGLRenderer | null>(null);
    const [cameraRef, setCamera] = useState<THREE.PerspectiveCamera | null>(null)

    useEffect(() => {
        if (transformation === undefined)
            return;
        let obj = scene.getObjectByName("cube");
        obj?.position.set(transformation.NewPosition.x, transformation.NewPosition.y, transformation.NewPosition.z);
        rendererRef.render(scene, cameraRef);
    }, [transformation])

    useEffect(() => {
        let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
        camera.position.z = 5
        setCamera(camera);

        let renderer = new THREE.WebGLRenderer();
        setRender(renderer);
    }, [])

    useEffect(() => {
        if(rendererRef === null) return
        if(cameraRef === null) return
        rendererRef.setSize(window.innerWidth, window.innerHeight);
        document.getElementById("canvas").appendChild(rendererRef.domElement);

        const geometry = new THREE.BoxGeometry(1, 1, 1);
        const material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
        const cube = new THREE.Mesh(geometry, material);
        cube.name = "cube";
        const geometry2 = new THREE.BoxGeometry(2, 1, 0);
        const material2 = new THREE.MeshBasicMaterial({ color: 0xff0000 });
        const cube2 = new THREE.Mesh(geometry2, material2);
        cube2.name = "cube2"
        //cube.add(cube2);

        scene.add(cube);

        cameraRef.position.z = 5;

        rendererRef.render(scene, cameraRef);
    }, [rendererRef])

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
            id="canvas"
        >
        </Box>
    );
}

export default Content;