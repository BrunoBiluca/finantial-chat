import { useState } from "react"

export default function MessageSendBox(props) {

    const [sendMessage, setSendMessage] = useState('')

    function sendChatMessage(e) {
        if(e.key !== 'Enter') return;

        let newMessage = { created_at: Date.now(), user: props.user, message: sendMessage }
        setSendMessage('')
        props.onNewMessage(newMessage)
    }

    return (
        <div className="chat-send">
            <input placeholder="Enter message...." type="text" value={sendMessage} onChange={e => setSendMessage(e.target.value)} onKeyDown={sendChatMessage} />
            <button onClick={sendChatMessage}>Send</button>
        </div>
    )
}