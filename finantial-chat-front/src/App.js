import React, { useState } from 'react'
import MessageBoard from './MessageBoard'
import './App.css'

function App() {

  const [user, setUser] = useState('Bruno')
  const [message, setMessage] = useState()
  const [messagesList, setMessagesList] = useState([
    {'user': 'user 1', "message": "message 1"},
    {'user': 'user 2', "message": "message 2"},
    {'user': 'user 1', "message": "message 3"},
    {'user': 'user 2', "message": "message 4"},
    {'user': 'user 1', "message": "message 5"}
  ])

  function sendMessage(){
    let newMessage = {user: user, message: message}
    setMessage('')
    setMessagesList([...messagesList, newMessage])
  }

  return (
    <div className="chat">
      <div className="chat-users">
        <h3>On-line users</h3>
        <p> - Bruno</p>
        <h3>Off-line users</h3>
      </div>
      <div className="chat-main">
        <MessageBoard messages={messagesList}/>
        <div className="chat-send">
          <input placeholder="Enter message...." type="text" value={message} onChange={e => setMessage(e.target.value)}/>
          <button onClick={sendMessage}>Send</button>
        </div>
      </div>
    </div>
  );
}

export default App;
