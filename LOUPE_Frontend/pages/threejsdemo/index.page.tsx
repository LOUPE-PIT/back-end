import React, {useEffect} from 'react'
import './code.css'
import { Canvas, useThree} from '@react-three/fiber'
import Duck from '../../3Dobjectcomponents/duck';
import { OrbitControls } from '@react-three/drei';

export { Page }

function Controls() {
    const {
        camera,
        gl: {domElement},
    } = useThree();

    return <OrbitControls args={[camera, domElement]} />;
}

function Page() {
    return (
        <>
            <h1>ThreeJS Demo</h1>
            <Canvas style={{"position": "absolute"}}>
                <ambientLight />
                <pointLight position={[5,5,5]} intensity={1} />
                <pointLight position={[-3,-3,2]} intensity={1} />
                <Controls />
                <Duck />
            </Canvas>
        </>
    )
}