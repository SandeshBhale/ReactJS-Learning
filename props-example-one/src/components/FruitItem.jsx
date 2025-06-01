const FruitItem = ({ onefruit,ind }) => {
    const HandleClick = (event) => {
        console.log(event);
        console.log(`Buy Clicked! ${onefruit}`);
    }

    return <li>{onefruit} - {ind} <button onClick={(event) => HandleClick(event)}>Buy</button></li>
}
export default FruitItem;