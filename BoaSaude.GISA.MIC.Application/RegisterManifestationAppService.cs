using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using BoaSaude.GISA.MIC.Domain;
using BoaSaude.GISA.MIC.Domain.Entities;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Application
{
    public class RegisterManifestationAppService : IRegisterManifestationAppService
    {
        private readonly IManifestationRepository _manifestationRepository;
        private readonly IMessageBrokerRepository _messageBrokerRepository;

        public RegisterManifestationAppService(IManifestationRepository manifestationRepository,
            IMessageBrokerRepository messageBrokerRepository)
        {
            _manifestationRepository = manifestationRepository;
            _messageBrokerRepository = messageBrokerRepository;
        }

        public async Task Execute(RegisterManifestationViewModel registerManifestationViewModel)
        {
            var manifestation = new Manifestation
            {
                AttendanceId = registerManifestationViewModel.AttendanceId,
                CreationDate = DateTime.UtcNow,
                Description = registerManifestationViewModel.Description,
                Login = registerManifestationViewModel.Login,
                Type = registerManifestationViewModel.Type
            };

            await _manifestationRepository.Add(manifestation);

            await NotifyManifestationRegister(registerManifestationViewModel, manifestation);
        }

        private async Task NotifyManifestationRegister(RegisterManifestationViewModel registerManifestationViewModel, Manifestation manifestation)
        {
            var message = new
            {
                registerManifestationViewModel.Login,
                registerManifestationViewModel.AttendanceId,
                manifestationId = manifestation.Id,
                manifestation.CreationDate
            };

            await _messageBrokerRepository.PostTopicMessage(message, Constants.TopicName.ManifestationRegister);
        }
    }
}
