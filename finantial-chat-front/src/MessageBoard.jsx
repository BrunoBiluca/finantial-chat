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

    let sortedMessages = props.messages.sort(function (first, second) {
        return first.created_at - second.created_at;
    })

    const generateKey = (pre) => {
        return `${ pre }_${ new Date().getTime() }`;
    }

    return (
        <div className="chat-messages">
            {sortedMessages.map((message, index) => {
                return <MessageItem key={index} message={message} />
            })}
            <div style={{ margin: 0, padding: 0, border: 0 }} ref={messagesEndRef}></div>
        </div>
    )
}