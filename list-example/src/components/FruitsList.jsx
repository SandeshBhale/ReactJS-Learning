function FruitsList() {

    let fruits = ["Orange", "Mango", "Apple", "Banana", "PineApple", "Kiwi"]
    //let fruits = [""]

    let message = fruits.length === 0 ? "No fruits found" : ""
    //let message = Fruits.length === 0 && <h2> No Fruits Found</h2>;
    return (
        <>
            <h1>Fruits List</h1>
            {message}
            <hr />

            <ul>
                {
                    fruits.map((item, index) => (
                        <li key={item}>{item}</li>
                    ))
                }
            </ul>
        </>
    );
}

export default FruitsList;