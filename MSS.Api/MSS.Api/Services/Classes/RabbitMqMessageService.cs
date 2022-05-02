using MSS.Api.Services.Interfaces;
using System;
using System.Text;
using RabbitMQ.Client;

namespace MSS.Api.Services.Classes
{
    public class RabbitMqMessageService : IMessageService
    {
        private ILogger Logger { get; set; }
        private ConnectionFactory RabbitMqConnectionFactory { get; set; }
        public RabbitMqMessageService(ILogger<RabbitMqMessageService> logger, ConnectionFactory rabbitMqConnectionFactory)
        {
            Logger = logger;
            RabbitMqConnectionFactory = rabbitMqConnectionFactory;
        }
        public async Task Produce(string message)
        {
            Logger.LogInformation($"Writing {message} to message queue");

            using (var connection = RabbitMqConnectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mss",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "mss",
                    basicProperties: null,
                    body: body);

                Logger.LogInformation($"Sent message {message}");
            }
        }
    }
}
