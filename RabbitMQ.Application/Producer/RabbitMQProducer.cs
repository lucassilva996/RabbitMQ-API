using System;
using RabbitMQ.Client;
using RabbitMQ.Application.Interfaces.RabbitMQ;
using System.Text.Json;
using System.Text;

namespace RabbitMQ.Application.Producer
{
	public class RabbitMQProducer : IRabbitMQProducer
	{
        public void SendProductMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("product", exclusive: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "product", body: body);
        }

    }
}

