using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Domain.Repositories
{
    public interface IMessageBrokerRepository
    {
        Task PostQueueMessage(object message, string queueName);
        Task PostTopicMessage(object message, string topicName);
    }
}
