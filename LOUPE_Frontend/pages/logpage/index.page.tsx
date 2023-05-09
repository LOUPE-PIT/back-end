import React from 'react';
import './code.css';
import LogData from './components/LogDataComponent';

export { Page }

function Page() {
  return (
    <div className='logContent'>
      <h1 className='title'>Geschiedenis</h1>
      <LogData />
    </div>
  )
}
