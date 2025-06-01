const Message = ({ fruitlist }) => {
    return fruitlist.length === 0 && <h2>No Fruits in list</h2>
};
export default Message;