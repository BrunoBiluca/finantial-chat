import MessageItem from "./MessageItem"

export default function MessageBoard(props){

    return (
        <div className="chat-messages">
            {props.messages.map(message => {
                return <MessageItem key={message.created_at} message={message} />
            })}
        </div>
    )
}