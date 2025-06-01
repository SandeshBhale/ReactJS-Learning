import FruitItem from './FruitItem';
const FruitsList = ({ fruitlist }) => {
    return (
        <>
            <ul>
                {fruitlist.map((item, index) => (
                    <FruitItem key={item} onefruit={item} ind={index} />
                ))}
            </ul>
        </>
    );
};
export default FruitsList;