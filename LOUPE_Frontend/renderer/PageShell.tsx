import React from 'react'
import logo from './logo.svg'
import { PageContextProvider } from './usePageContext'
import type { PageContext } from './types'
import './PageShell.css'
import { Link } from './Link'
import GlobalServices from '../server/GlobalServices'
import {FaHome, FaUsers, FaUser, FaSignOutAlt} from 'react-icons/fa';
import { PublicClientApplication, EventType, EventMessage, AuthenticationResult, InteractionRequiredAuthError  } from '@azure/msal-browser';
import { MsalProvider, useMsal, useIsAuthenticated} from "@azure/msal-react";
import { useEffect } from "react";


export { PageShell }

function PageShell({ children, pageContext, msalInstance }: { children: React.ReactNode; pageContext: PageContext, msalInstance: any }) {
  return (
    <React.StrictMode>
      <GlobalServices>
      <MsalProvider instance={msalInstance}>
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
              <Link className="navitem" href="/logpage">
                <FaUsers />
              </Link>
              <Link className="navitem logout" href="#">
                <FaSignOutAlt />
              </Link>
            </Sidebar>
            <Content>{children}</Content>
          </Layout>
        </PageContextProvider>
        </MsalProvider>
      </GlobalServices>
    </React.StrictMode>
  )
}

const pca = new PublicClientApplication({
  auth: {
      clientId: '209f7026-2915-41d9-8e2e-8872571b7efb',
      authority: 'https://login.microsoftonline.com/0a4457cd-eb55-4625-b2fc-9dc4c6e509aa',
      redirectUri: '/'
  },
  cache: {
      cacheLocation: 'localStorage',
      storeAuthStateInCookie: false,
  },
  system: {
      loggerOptions: {
          loggerCallback: (level, message, containsPII) => {
              console.log(message)
          },

      }
  }

})


pca.addEventCallback(event => {
  if(event.eventType === EventType.LOGIN_SUCCESS) {
      console.log(event);
      const payload = event.payload as AuthenticationResult;
      const account = payload.account;
      pca.setActiveAccount(account);
  }
});

  const { instance } = useMsal();
  const isAuthenticated: any = useIsAuthenticated();

useEffect(() => {
  if(!isAuthenticated) {
      instance.ssoSilent({
          scopes: ["user.read"],
          loginHint: "yarikbrouwer@hotmail.com"
      }).then((response) => {
        instance.setActiveAccount(response.account);
      }).catch((error: any) => {
        if(error instanceof InteractionRequiredAuthError){
            instance.loginRedirect({
                scopes: ["user.read"],
            });
        }
    });
  }
}, [])


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
        <img src={logo} height={64} width={64} alt="logo" />
      </a>
    </div>
  )
}
