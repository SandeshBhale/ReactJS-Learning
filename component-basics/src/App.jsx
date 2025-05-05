import { useState } from 'react'
import Welcome from './components/Welcome'
import Message from './components/message'

function App() {

  return (
    <>
      <div>
        <Message></Message>
        <Welcome></Welcome>
      </div>
    </>
  )
}

export default App
