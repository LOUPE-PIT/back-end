import React from 'react'
import logo from './logo.svg'
import { PageContextProvider } from './usePageContext'
import type { PageContext } from './types'
import './PageShell.css'
import { Link } from './Link'
import GlobalServices from '../server/GlobalServices'
import {FaHome, FaUsers, FaUser, FaSignOutAlt} from 'react-icons/fa';

export { PageShell }

function PageShell({ children, pageContext }: { children: React.ReactNode; pageContext: PageContext }) {
  return (
    <React.StrictMode>
      <GlobalServices>
        <PageContextProvider pageContext={pageContext}>
          <Layout>
            <Sidebar>
              <Logo />
              <Link className="navitem" href="/">
                <FaHome />
              </Link>
              <Link className="navitem" href="/about">
                <FaUser />
              </Link>
              <Link className="navitem" href="/log">
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
    </React.StrictMode>
  )
}

function Layout({ children }: { children: React.ReactNode }) {
  return (
    <div
      style={{
        display: 'flex',
        margin: 'auto'
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
        minHeight: '100vh'
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
        <img src={logo} height={64} width={64} alt="logo" />
      </a>
    </div>
  )
}
