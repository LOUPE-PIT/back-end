import React from 'react';
import './code.css';
import Connection from './signalRHub';

export { Page }

function Page() {
  return (
    <Connection roomId = "Room1"></Connection>
  )
}