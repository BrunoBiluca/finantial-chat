import React from "react"
import { useState } from "react"
import axios from "axios"
import { Redirect } from "react-router-dom"

export default function Login() {

    const [name, setName] = useState()
    const [pass, setPass] = useState()

    function login() {
        let userLogin = {
            name: name,
            password: pass
        }

        console.log("user", userLogin)
        axios.post('http://localhost:44315/api/auth', userLogin)
            .then(response => {
                console.log(response.data)
                sessionStorage.setItem('user', JSON.stringify({ user: userLogin }))
                window.location = 'chat'
            });
    }
    
    let user = JSON.parse(sessionStorage.getItem('user'))
    if (user !== null) {
        return <Redirect to="/chat"></Redirect>
    }

    return (
        <div>
            <div>
                <p>Name</p>
                <input type="text" onChange={(e) => { setName(e.target.value) }} />
            </div>
            <div>
                <p>Password</p>
                <input type="password" onChange={(e) => { setPass(e.target.value) }} />
            </div>
            <button onClick={login}>Login</button>
        </div>
    )
}