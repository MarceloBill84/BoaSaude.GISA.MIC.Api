namespace BoaSaude.GISA.MIC.Domain.Repositories
{
	public interface IMessageBrokerRepository
	{
		void PostQueueMessage(object message, string queueName);
		void PostTopicMessage(object message, string topicName);
	}
}
