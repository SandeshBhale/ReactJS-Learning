import { useState } from 'react'
import Welcome from './components/Welcome'
import Message from './components/message'

function App() {

  return (
    <>
      <div>
        <Welcome />
        <hr />
        <Message />
        <hr />
        <Message />
        <hr />
        <Welcome/>
      </div>
    </>
  )
}

export default App
