using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
	public class MessageBrokerRepository : IMessageBrokerRepository
	{
		private readonly ApplicationConfig _applicationConfig;

		public MessageBrokerRepository(ApplicationConfig applicationConfig)
		{
			_applicationConfig = applicationConfig;
		}

		public void PostQueueMessage(object message, string queueName)
		{
			var channel = GetChannel();
			var messageProperties = GetMessageProperties(channel);
			var body = ConvertMessage(message);

			channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: messageProperties, body: body);
		}

		public void PostTopicMessage(object message, string topicName)
		{
			var channel = GetChannel();
			var messageProperties = GetMessageProperties(channel);
			var body = ConvertMessage(message);

			channel.BasicPublish(exchange: topicName, routingKey: string.Empty, basicProperties: messageProperties, body: body);
		}

		private static byte[] ConvertMessage(object message)
		{
			var json = JsonConvert.SerializeObject(message);
			return Encoding.Default.GetBytes(json);
		}

		private IModel GetChannel()
		{
			var factory = new ConnectionFactory()
			{
				HostName = _applicationConfig.MessageBrokerConfig.HostName,
				UserName = _applicationConfig.MessageBrokerConfig.UserName,
				Password = _applicationConfig.MessageBrokerConfig.Password,
			};

			IConnection connection = factory.CreateConnection();

			return connection.CreateModel();
		}

		private IBasicProperties GetMessageProperties(IModel channel)
		{
			var messageProperties = channel.CreateBasicProperties();
			messageProperties.Persistent = true;

			return messageProperties;
		}
	}
}
