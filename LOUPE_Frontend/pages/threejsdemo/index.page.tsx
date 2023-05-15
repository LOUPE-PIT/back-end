import React from 'react'
import './code.css'
import Header from "./Layout/header";
import Content from "./Layout/content";
import { useLocation } from "react-router-dom"

export { Page }


function Page() {
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const roomCode = queryParams.get("roomCode");
    
    return (
        <>
            <Header
                roomCode={roomCode || ""}
            />
            <Content />
        </>
    )
}