using MSS.Service.Services.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Service.Services.Classes
{
    public class RabbitMqMessageService : IMessageService
    {
        private ConnectionFactory RabbitMqConnectionFactory { get; set; }

        public RabbitMqMessageService(ConnectionFactory rabbitMqConnectionFactory)
        {
            RabbitMqConnectionFactory = rabbitMqConnectionFactory;
        }

        public async Task Consume()
        {
            using (var connection = RabbitMqConnectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mss",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "mss",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
