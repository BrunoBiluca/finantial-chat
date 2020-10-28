# Finantial Chat

For this project I choose to implement a React front-end that request two apis, ChatApi, that handles the users messages and providers authentication and StockConsultantBotApi, a decoulped api that handles the resquest about stock prices.

Authentication was implemented using Identity Framework from AspNetCore, using a Postgres database to persist.

All users messages are storage on MongoDb.

I couldn't make the RabbitMQ consumer on ChatApi, to get the messages sended by the Bot, but I could make StockConsultantBotApi send messages to RabbitMQ, if you are willing I want your feedback in how could I made that work.

Except for the RabbitMQ I could implement all the other features.

It was a very interesting project, I learned a lot and thank you guys very much for that oportunity.

This is the main screen of the application:

![Chat Screen](https://github.com/BrunoBiluca/finantial-chat/blob/main/chat-screen.PNG)

# How to use

## Requirements
  - Docker and Docker-Compose
  - It is faster if you run your Docker on Windows Subsystem Linux 2 or Linux

## Front-end (React)

It is need to have installed **Node**, you can find the link [here](https://nodejs.org/pt-br/).

After Node is installed go to the finantial-chat-front folder, install the packages and start the application.

```
cd finantial-chat-front
npm install
npm start
```

Front-end is good to go and runs on `localhost:3000`.

## ChatApi

It is need to have **dotnet envoriment** installed, you can find the link [here](https://dotnet.microsoft.com/download).

After dotnet is installed, start the docker-compose used to message storage and users manager

```
cd FinantialChat
docker-compose up -d
```

This will start
- Mongo Express: mongo dashboard, very useful to check data
  - access on: `localhost:8081`
- MongoDb: our dabatase to store messages
- Postgres: our database to manager users, using Identity

After docker is runnig go to the ChatApi folder, install all packages and run the application.

```
cd ChatApi
dotnet restore
dotnet dotnet ef database update
dotnet run
```

ChatAPI runs on `localhost:44315`

## StockConsultantBotApi

If the ChatAPI is up and running the StockConsultantBotApi is a lot more simple to execute.

So access FinantialChat/StockConsultantBot, install all packages and start running the application.

```
cd FinantialChat/StockConsultantBot
dotnet restore
dotnet run
```

StockConsultantBot runs on `localhost:44316`

## Create User

To create a user check the postman collection that has the examples to Register and Authenticate a user.

Or you can send a request to:

```
POST http://localhost:44315/api/register
{
    "user": "username",
    "password": "test" 
}
```
