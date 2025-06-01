import './App.css'
import Message from './components/Message'
import FruitsList from './components/FruitsList'

function App() {

  let fruits = ['Apple', 'Mango', 'Banana', 'Orange', 'Grapes', 'Pineapple']

  return (
    <>
      <h1>Fruits List</h1>
      <Message fruitlist={fruits} />
      <FruitsList fruitlist={fruits} />
    </>
  )
}

export default App
