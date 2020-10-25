export default function MessageItem(props) {
    return (
        <div className="message">
            <p>{props.message.user}</p>
            <p>{props.message.message}</p>
        </div>
    )
}