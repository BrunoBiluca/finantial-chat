import { createRef, useEffect } from "react"
import MessageItem from "./MessageItem"

export default function MessageBoard(props) {
    const messagesEndRef = createRef()

    useEffect(() => {
        scrollToBottom()
    }, [props.messages])

    function scrollToBottom() {
        messagesEndRef.current.scrollIntoView({ behavior: 'smooth' })
    }

    return (
        <div className="chat-messages">
            {props.messages.map(message => {
                return <MessageItem key={message.created_at} message={message} />
            })}
            <div style={{margin: 0, padding: 0, border: 0}} ref={messagesEndRef}></div>
        </div>
    )
}