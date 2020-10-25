import { useState } from "react"

var StockConsultantBotApiUrl = "http://localhost:44316"

export default function MessageSendBox(props) {

    const [sendMessage, setSendMessage] = useState('')

    function sendCommand(){

        if(!sendMessage.startsWith("/stock=")){
            let newMessage = { created_at: Date.now(), user: 'Stock Bot', message: "Sorry I don't understant this command, please try /stock=stock_name" }
            props.onNewMessage(newMessage)
            return;
        }

        try{
            let stockName = sendMessage.split('=')[1]
            
            fetch(`${StockConsultantBotApiUrl}/api/stock-consultant-bot/${stockName}`)
            .then(r => {
                r.text().then(response => {
                    let newMessage = { created_at: Date.now(), user: 'Stock Bot', message: response}
                    props.onNewMessage(newMessage)
                })                
            })
            .catch(err => {
                console.log("[ERROR]", err.message)
                let newMessage = { created_at: Date.now(), user: 'Stock Bot', message: err.message}
                props.onNewMessage(newMessage)
                console.log(err)
            })
        }catch (e) {
            console.log(e)
        }
    }

    function sendChatMessage() {

        if(sendMessage.startsWith('/')){
            sendCommand();
            setSendMessage('')
            return;
        }

        let newMessage = { created_at: Date.now(), user: props.user, message: sendMessage }
        setSendMessage('')
        props.onNewMessage(newMessage)
    }

    return (
        <div className="chat-send">
            <input 
                placeholder="Enter message...." 
                type="text" 
                value={sendMessage} 
                onChange={e => setSendMessage(e.target.value)} 
                onKeyDown={(e) => {
                    if(e.key !== 'Enter') return;
                    sendChatMessage()
                }} 
            />
            <button onClick={sendChatMessage}>Send</button>
        </div>
    )
}