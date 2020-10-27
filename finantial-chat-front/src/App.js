import React, { useEffect, useState } from 'react'
import MessageBoard from './MessageBoard'
import './App.css'
import MessageSendBox from './MessageSendBox';

const welcomeMessage = { 'created_at': 0, 'user': 'Bruno', "message": "Welcome to your Finantial Chat Room, talk about financies with your friends and enjoy check or Stock Consultant Bot service. Thanks."}

function App() {
  const chatApiURL = "ws://localhost:44315"

  var browser = window.navigator.userAgent.includes('Edg') ? 'Edge': 'Chrome';

  const [user, setUser] = useState(browser)

  const [messagesList, setMessagesList] = useState([welcomeMessage])

  const [ws, setWs] = useState(new WebSocket(chatApiURL))

  useEffect(() => {
    fetch("http://localhost:44315/api/chat-messages")
    .then(r => {
      r.json().then(response => {
        setMessagesList([welcomeMessage, ...response])
      })
    })
  }, [])

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
      setWs(new WebSocket(chatApiURL))
    }
  }, [messagesList])

  function addMessage(newMessage){
    setMessagesList([...messagesList.slice(-50), newMessage])
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
