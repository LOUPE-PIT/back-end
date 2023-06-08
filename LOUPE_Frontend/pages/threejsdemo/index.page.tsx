import React from 'react'
import './code.css'
import {useState} from "react";
import Header from "./Layout/header";
import Content from "./Layout/content";
import Connection from "../signalR/signalRHub"
import {Synchronization} from "../signalR/signalRHub"

export { Page }

function Page() {
    const [transformation, setTransformation] = useState<Synchronization>();
    return (
        <>
            <Connection roomId = "3fa85f64-5717-4562-b3fc-2c963f66afa6" setTransformation = {setTransformation} />
                <Header/>
                <Content transformation={transformation}/>
        </>
    )
}