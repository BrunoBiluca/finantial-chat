import React, { useEffect, useState } from 'react'
import MessageBoard from './MessageBoard'
import './App.css'
import MessageSendBox from './MessageSendBox';

function App() {
  const chatApiURL = "ws://localhost:44315"

  var browser = window.navigator.userAgent.includes('Edg') ? 'Edge': 'Chrome';

  const [user, setUser] = useState(browser)

  const [messagesList, setMessagesList] = useState([
    { 'created_at': 0, 'user': 'Bruno', "message": "Welcome to your Finantial Chat Room, talk about financies with your friends and enjoy check or Stock Consultant Bot service. Thanks."}
  ])

  const [ws, setWs] = useState(new WebSocket(chatApiURL))

  useEffect(() => {
    // TODO: get here message history

    ws.onopen = () => {
      console.log('connected')
    }

    ws.onmessage = evt => {
      const message = JSON.parse(evt.data)
      addMessage(message)
    }

    ws.onclose = () => {
      console.log('disconnected')
      setWs(new WebSocket(chatApiURL))
    }
  }, [messagesList])

  function addMessage(newMessage){
    setMessagesList([...messagesList, newMessage])
  }

  function onNewMessage(newMessage){
    if(ws.readyState === ws.OPEN){
      ws.send(JSON.stringify(newMessage))
    }
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
