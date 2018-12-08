using System;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace NotificationEngine.Services
{
    public class NotificationProducerService
    {
        public void Publish(Notification notification)
        {
            Console.WriteLine("---GoingRabbit---Notification Starts-----");
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "rabbitmq",
                Password = "rabbitmq"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "Notification",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            string _notification = JsonConvert.SerializeObject(notification);
            var producer = Encoding.UTF8.GetBytes(_notification);

            channel.BasicPublish(
                exchange: "",
                routingKey: "Notification",
                basicProperties: null,
                body: producer
            );
            Console.WriteLine("----published    ----", producer);
        }
    }
}