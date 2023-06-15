import { Box } from "@chakra-ui/layout";
import React, { useEffect, useState } from "react";
import Duck from "../../../3Dobjectcomponents/duck";
import { Redbutton } from "../../../3Dobjectcomponents/redbutton";
import { Canvas, context, useThree } from "@react-three/fiber";
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
import { Synchronization } from "../../signalR/signalRHub"
import * as THREE from 'three';
import { delay } from "framer-motion";

const Content = ({ transformation }: { transformation: Synchronization }) => {
    const [scene] = useState<THREE.Scene>(new THREE.Scene());
    const [rendererRef, setRender] = useState<THREE.WebGLRenderer | null>(null);
    const [cameraRef, setCamera] = useState<THREE.PerspectiveCamera | null>(null)
    const [controlRef, setControls] = useState<OrbitControls | null>(null)

    useEffect(() => {
        if (transformation === undefined)
        return;

        let obj = scene.getObjectByName(transformation.ObjectName);
        
        if(transformation.NewPosition.x === -1 && transformation.NewPosition.y === -1 && transformation.NewPosition.z === -1){
            obj?.rotation.set(0, transformation.DegreesRotation, 0);
        }
        else{
            obj?.position.set(transformation.NewPosition.x, transformation.NewPosition.y, transformation.NewPosition.z);
        }

        rendererRef.render(scene, cameraRef);
    }, [transformation])

    useEffect(() => {
        let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
        camera.position.z = 5
        setCamera(camera);

        let renderer = new THREE.WebGLRenderer();
        setRender(renderer);
        
        const controls:OrbitControls = new OrbitControls( camera, renderer.domElement );
        setControls(controls);
        controls.update();
    }, [])

    useEffect(() => {
        if(rendererRef === null) return
        if(cameraRef === null) return
        rendererRef.setSize(window.innerWidth, window.innerHeight);
        document.getElementById("canvas").appendChild(rendererRef.domElement);

        const geometry = new THREE.BoxGeometry(1, 1, 1);
        const material = new THREE.MeshBasicMaterial({ color: 0xffffff });
        const cube = new THREE.Mesh(geometry, material);
        cube.name = "cube";
        const geometry2 = new THREE.CylinderGeometry(1, 1, 0.3, 100);
        const material2 = new THREE.MeshBasicMaterial({ color: 0x0000ff });
        const cube2 = new THREE.Mesh(geometry2, material2);
        cube2.name = "cube2"
        cube.add(cube2);

        scene.add(cube);

        cameraRef.position.z = 5;

        rendererRef.render(scene, cameraRef);
    }, [rendererRef])

    function animate() {
        if(rendererRef === null || cameraRef === null || scene === null) return;
        requestAnimationFrame( animate );
    
        controlRef.update();

        rendererRef.render( scene, cameraRef );
    }

    animate();

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