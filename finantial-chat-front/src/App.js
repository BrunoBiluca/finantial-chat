import React, { useEffect, useState } from 'react'
import MessageBoard from './MessageBoard'
import './App.css'
import MessageSendBox from './MessageSendBox';

function App() {
  const chatApiURL = "wss://localhost:44315"

  var browser = window.navigator.userAgent.includes('Edg') ? 'Edge': 'Chrome';

  const [user, setUser] = useState(browser)

  const [messagesList, setMessagesList] = useState([
    { 'created_at': 0, 'user': 'user 1', "message": "message 1"}
  ])

  let ws = new WebSocket(chatApiURL)

  useEffect(() => {
    ws.onopen = () => {
      console.log('connected')
    }

    ws.onmessage = evt => {
      const message = JSON.parse(evt.data)
      addMessage(message)
    }

    ws.onclose = () => {
      console.log('disconnected')
      ws = new WebSocket(chatApiURL)
    }
  }, [])

  function addMessage(newMessage){
    setMessagesList([...messagesList, newMessage])
  }

  function onNewMessage(newMessage){
    if(ws.readyState === ws.OPEN){
      ws.send(JSON.stringify(newMessage))
    }
    addMessage(newMessage)

  }

  return (
    <div className="chat">
      <div className="chat-users">
        <h3>On-line users</h3>
        <p> - {user}</p>
        <h3>Off-line users</h3>
      </div>
      <div className="chat-main">
        <MessageBoard messages={messagesList}/>
        <MessageSendBox user={user} onNewMessage={onNewMessage}/>
      </div>
    </div>
  );
}

export default App;
