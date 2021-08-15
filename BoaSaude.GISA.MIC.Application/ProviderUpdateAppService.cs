using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using BoaSaude.GISA.MIC.Domain;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Application
{
	public class ProviderUpdateAppService : IProviderUpdateAppService
	{
		private readonly IMessageBrokerRepository _messageBrokerRepository;

		public ProviderUpdateAppService(IMessageBrokerRepository messageBrokerRepository)
		{
			_messageBrokerRepository = messageBrokerRepository;
		}

		public async Task Execute(ProviderUpdateViewModel providerUpdateViewModel)
		{
			_messageBrokerRepository.PostTopicMessage(providerUpdateViewModel, Constants.TopicName.TopicProviderUpdate);
		}
	}
}
