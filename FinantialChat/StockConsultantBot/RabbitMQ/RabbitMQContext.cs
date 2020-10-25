using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockConsultantBot.RabbitMQ {

    public class RabbitMQContext {

        public static void SendMessage(ChatMessage chatMessage) {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "rabbitmq", Password = "rabbitmq" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "bot-messages",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            string message = JsonSerializer.Serialize(chatMessage);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "bot-messages",
                basicProperties: null,
                body: body
            );
        }
    }
}
