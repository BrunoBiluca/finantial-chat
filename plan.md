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
  - _ Get message history
  - _ Pass a json objecto to configure MongoDB, instead of one on one attributes
  - _ Change initial page on build to swagger

- StockConsultantBot
  - _ Create bot api
  - _ Create Get endpoint
  - _ Parse CSV to result output

- FrontEnd
  - &check; Chat user interface
  - &check; Front-end refactor to better compoments
  - &check; Add Enter to send messages
  - _ Create command pattern
    - _ Send request to StockConsultantBot to get the result
  - _ Sort messages by timestamp
  - _ Test for React render
  - _ Chat interface using the 100% height
  - _ layout v2
    - _ rounded button
    - _ better colors
  - stick chat-message to bottom when updated

- Authentication

- Refactor
  - _ Chat Api organize folder hierarchy
  - _ Front End organize folder hierarchy

- Bugs
  - _ Last sended message is ovewritten on chat message board

## Secondary goals

- &check; Chat display messages from previous days with full date formatted
- _ Chat will show when user is connected and disconnected
- _ Chat statistics
  - _ currentClients
  - _ totalClients

# Questions:
 - What is build an installer?
   - Maybe is the web ap ready to deploy
 