using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
    public class MessageBrokerRepository : IMessageBrokerRepository
    {
        private readonly ApplicationConfig _applicationConfig;

        public MessageBrokerRepository(ApplicationConfig applicationConfig)
        {
            _applicationConfig = applicationConfig;
        }

        public async Task PostQueueMessage(object message, string queueName)
        {
            var channel = await GetChannel();

            await channel.QueueDeclareAsync(queueName);

            var body = ConvertMessage(message);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body);
        }

        public async Task PostTopicMessage(object message, string topicName)
        {
            var channel = await GetChannel();

            await channel.ExchangeDeclareAsync(topicName, ExchangeType.Topic);

            var body = ConvertMessage(message);

            await channel.BasicPublishAsync(exchange: topicName, routingKey: string.Empty, body: body);
        }

        private static byte[] ConvertMessage(object message)
        {
            var json = JsonConvert.SerializeObject(message);
            return Encoding.Default.GetBytes(json);
        }

        private async Task<IChannel> GetChannel()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _applicationConfig.MessageBrokerConfig.HostName,
                UserName = _applicationConfig.MessageBrokerConfig.UserName,
                Password = _applicationConfig.MessageBrokerConfig.Password,
            };

            IConnection connection = await factory.CreateConnectionAsync();

            return await connection.CreateChannelAsync();
        }
    }
}
