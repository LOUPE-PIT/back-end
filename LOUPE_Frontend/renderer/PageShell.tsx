import React from 'react'
import { PageContextProvider } from './usePageContext'
import type { PageContext } from './types'
import './PageShell.css'
import { Link } from './Link'
import GlobalServices from '../server/GlobalServices'
import { FaHome, FaUsers, FaUser, FaSignOutAlt } from 'react-icons/fa';
import { ChakraProvider } from '@chakra-ui/react'
import Chat from '../pages/signalR/signalRHub'

export { PageShell }

function PageShell({ children, pageContext }: { children: React.ReactNode; pageContext: PageContext }) {
  return (
    <React.StrictMode>
      <ChakraProvider>
        <GlobalServices>
          <PageContextProvider pageContext={pageContext}>
            <Layout>
              <Sidebar>
                <Link className="navitem" href="/">
                  <FaHome />
                </Link>
                <Link className="navitem" href="/about">
                  <FaUser />
                </Link>
                <Link className="navitem" href="/groupOverview">
                  <FaUsers />
                </Link>
                <Link className="navitem logout" href="#">
                  <FaSignOutAlt />
                </Link>
              </Sidebar>
              <Content>{children}</Content>
            </Layout>
          </PageContextProvider>
        </GlobalServices>
      </ChakraProvider>
    </React.StrictMode>
  )
}

function Layout({children}: { children: React.ReactNode }) {
    return (
        <div
            style={{
                display: 'flex'
            }}
        >
            {children}
        </div>
    )
}

function Sidebar({ children }: { children: React.ReactNode }) {
  return (
    <div
      className='sidebar'
      style={{
        padding: 0,
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

function Content({ children }: { children: React.ReactNode }) {
  return (
    <div
      style={{
        padding: 20,
        paddingBottom: 50,
        borderLeft: '2px solid #eee',
        minHeight: '100vh',
        width: '100%'
      }}
    >
      {children}
    </div>
  )
}
