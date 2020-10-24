import React from 'react';
import './App.css';

function App() {
  return (
    <div className="chat">
      <div className="chat-users">
        <h3>On-line users</h3>
        <h3>Off-line users</h3>
      </div>
      <div className="chat-main">
        <div className="chat-messages">
          <div className="message">
            <p>User 1</p>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec mattis pellentesque placerat.</p>
          </div>
          <div className="message">
            <p>User 2</p>
            <p>Maecenas mollis condimentum rutrum. Morbi vitae nisl luctus neque auctor aliquet.</p>
          </div>
          <div className="message">
            <p>User 1</p>
            <p>Sed finibus, nisi sit amet condimentum dignissim, nunc tellus laoreet enim, quis semper tellus ipsum vitae felis. Pellentesque blandit sed nisl vitae convallis. In scelerisque vehicula euismod. Donec sit amet odio fermentum, sodales ex in, lobortis velit. Praesent rutrum interdum mi et hendrerit.</p>
          </div>
          <div className="message">
            <p>User 1</p>
            <p>Sed finibus, nisi sit amet condimentum dignissim, nunc tellus laoreet enim, quis semper tellus ipsum vitae felis. Pellentesque blandit sed nisl vitae convallis. In scelerisque vehicula euismod. Donec sit amet odio fermentum, sodales ex in, lobortis velit. Praesent rutrum interdum mi et hendrerit.</p>
          </div>
          <div className="message">
            <p>User 1</p>
            <p>Sed finibus, nisi sit amet condimentum dignissim, nunc tellus laoreet enim, quis semper tellus ipsum vitae felis. Pellentesque blandit sed nisl vitae convallis. In scelerisque vehicula euismod. Donec sit amet odio fermentum, sodales ex in, lobortis velit. Praesent rutrum interdum mi et hendrerit.</p>
          </div>
          <div className="message bot-message">
            <p>Stock Consultant Bot</p>
            <p>APPL.US quote is $93.42 per share</p>
          </div>
          <div className="message">
            <p>User 2</p>
            <p>Sed finibus, nisi sit amet condimentum dignissim.</p>
          </div>
        </div>
        <div className="chat-send">
          <input type="text"/>
          <button>Send</button>
        </div>
      </div>
    </div>
  );
}

export default App;
