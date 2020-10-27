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
  - &check; Message persistence
    - &check; Convert created_at from Frontend to DateTime on Backend
  - &check; Add http protocol for local connections
  - &check; Pass a json objecto to configure MongoDB, instead of one on one attributes
  - _ Consume messages on Queue bot-messages
  - _ Check if user is register to persist the message
    - _ Create a user to Stock Bot, and bot users will not persist messages
  - _ Get message history
  - _ Change initial page on build to swagger

- StockConsultantBot
  - &check; Create bot api
  - &check; Create Get endpoint
  - &check; Parse CSV to result output
  - &check; Handle not existings stocks
  - &check; Handle generic bot problems
  - &check; Handle http response on all cases
  - &check; Connect to RabbitMQ to send this message to ChatAPI


- FrontEnd
  - &check; Chat user interface
  - &check; Front-end refactor to better compoments
  - &check; Add Enter to send messages
  - &check; Create command pattern
    - &check; Send request to StockConsultantBot to get the result
  - &check; Sort messages by timestamp
  - &check; Show only 50 messages
  - &check; stick chat-message to bottom when updated
  - _ Test for React render
  - _ Chat interface using the 100% height
  - _ layout v2
    - _ rounded button
    - _ better colors

- Authentication

- Deploy
  - _ Create a script to run all projects

- Refactor
  - _ Chat Api organize folder hierarchy
  - _ Front End organize folder hierarchy

- Bugs
  - &check; Last sended message is ovewritten on chat message board

## Secondary goals

- &check; Chat display messages from previous days with full date formatted
- _ Chat will show when user is connected and disconnected
- _ Chat statistics
  - _ currentClients
  - _ totalClients

# Questions:
 - What is build an installer?
   - Maybe is the web ap ready to deploy
 