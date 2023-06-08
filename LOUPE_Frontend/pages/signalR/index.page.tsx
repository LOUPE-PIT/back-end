import React from 'react';
import './code.css';
import Connection from './signalRHub';

export { Page }

function Page() {
  return (
    <Connection roomId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"></Connection>
  )
}