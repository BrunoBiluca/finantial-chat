using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ChatAPI.RabbitMQ {
    public class RabbitMQContext {
        public static IModel channel = null;

        public static void Listener() {

            if(channel != null) return;

            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "rabbitmq", Password = "rabbitmq" };
            using var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "bot-messages",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(RabbitMQContext.channel);
            consumer.Received += (model, ea) => {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(message);
            };
            RabbitMQContext.channel.BasicConsume(
                queue: "bot-messages",
                autoAck: true,
                consumer: consumer
            );


        }
    }
}
