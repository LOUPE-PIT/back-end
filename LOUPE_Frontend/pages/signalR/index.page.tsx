import React from 'react';
import './code.css';
import Connection from './signalRHub';

export { Page }

function Page() {
  return (
    <Connection roomId = "00000000-0000-0000-0000-000000000000"></Connection>
  )
}