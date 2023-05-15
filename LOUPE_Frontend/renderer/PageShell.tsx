import React from 'react'
import logo from './logo.svg'
import {PageContextProvider} from './usePageContext'
import type {PageContext} from './types'
import './PageShell.css'
import {Link} from './Link'
import GlobalServices from '../server/GlobalServices'
import {ChakraProvider} from '@chakra-ui/react'
import {BrowserRouter} from 'react-router-dom'


export {PageShell}

function PageShell({children, pageContext}: { children: React.ReactNode; pageContext: PageContext }) {
    return (
        <React.StrictMode>
            <BrowserRouter>
                <ChakraProvider>
                    <GlobalServices>
                        <PageContextProvider pageContext={pageContext}>
                            <Layout>
                                <Sidebar>
                                    <Logo/>
                                    <Link className="navitem" href="/">
                                        Home
                                    </Link>
                                    <Link className="navitem" href="/about">
                                        About
                                    </Link>
                                    <Link className="navitem" href="/log">
                                        Log
                                    </Link>
                                    <Link className="navitem" href="/groupOverview">
                                        Groepen
                                    </Link>
                                </Sidebar>
                                <Content>{children}</Content>
                            </Layout>
                        </PageContextProvider>
                    </GlobalServices>
                </ChakraProvider>
            </BrowserRouter>
        </React.StrictMode>
    )
}

function Layout({children}: { children: React.ReactNode }) {
    return (
        <div
            style={{
                display: 'flex',
                background: '#D3D3D3'
            }}
        >
            {children}
        </div>
    )
}

function Sidebar({children}: { children: React.ReactNode }) {
    return (
        <div
            className='sidebar'
            style={{
                padding: 20,
                flexShrink: 0,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                lineHeight: '1.8em'
            }}
        >
            {children}
        </div>
    )
}

function Content({children}: { children: React.ReactNode }) {
    return (
        <div
            style={{
                minHeight: '100vh',
                width: '100%'
            }}
        >
            {children}
        </div>
    )
}

function Logo() {
    return (
        <div
            style={{
                marginTop: 20,
                marginBottom: 10
            }}
        >
            <a href="/">
                <img src={logo} height={64} width={64} alt="logo"/>
            </a>
        </div>
    )
}
