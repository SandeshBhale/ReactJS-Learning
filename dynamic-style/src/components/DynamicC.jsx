function DynamicC() {

    let name = "Anil";
    let qty = 5;
    let price = 0.18;

    return (
        <>
            <h1 style={{ 'color': "orange", 'font-size': "3rem" }}>Welcome {name}</h1>
            <h1> Quantity = {qty * price} </h1>
        </>
    );
}

export default DynamicC