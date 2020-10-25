import MessageItem from "./MessageItem"

export default function MessageBoard(props){

    return (
        <div className="chat-messages">
            {props.messages.map(message => {
                return <MessageItem message={message} />
            })}
        </div>
    )
}