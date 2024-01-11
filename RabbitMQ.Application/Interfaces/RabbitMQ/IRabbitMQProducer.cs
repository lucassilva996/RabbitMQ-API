using System;
namespace RabbitMQ.Application.Interfaces.RabbitMQ
{
	public interface IRabbitMQProducer
	{
		void SendProductMessage<T>(T message);
	}
}

