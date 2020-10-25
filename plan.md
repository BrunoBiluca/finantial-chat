# Financial Chat

# Features

## Main features

- Chat rooms
  - Group of people to rang out and talk about stocks

- Stock consultant bot
  - Allow users to search stock prices

- Authentication
  - Users will be authenticated by .NET Identity 

## Non Functional Features

- Unit testing coverage all funcionalities
- Persist user's messages
- Documentation all features

# Project Architeture

![project_arquiteture.png](project_arquiteture.png)

# Task

- ChatAPI
  - &check; Check chat room theory
  - &check; Websocket connection between client-server
    - &check; Send the message
  - &check; Server broadcasts a message
  - _ Message persistence
  - _ Get message history  
  - _ Add http protocol for local connections

- StockConsultantBot

- FrontEnd
  - &check; Chat user interface
  - &check; Front-end refactor to better compoments
  - &check; Add Enter to send messages
  - _ Sort messages by timestamp
  - _ Test for React render
  - _ Chat interface using the 100% height
  - _ layout v2
    - _ rounded button
    - _ better colors
  - stick chat-message to bottom when updated

- Authentication

- Bugs
  - _ Last sended message is ovewritten on chat message board

## Secondary goals

- _ Chat will show when user is connected and disconnected
- _ Chat statistics
  - _ currentClients
  - _ totalClients

# Questions:
 - What is build an installer?
   - Maybe is the web ap ready to deploy
 