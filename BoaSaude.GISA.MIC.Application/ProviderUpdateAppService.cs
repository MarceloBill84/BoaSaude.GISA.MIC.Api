using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using BoaSaude.GISA.MIC.Domain;
using BoaSaude.GISA.MIC.Domain.Enums;
using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Application
{
    public class ProviderUpdateAppService : IProviderUpdateAppService
    {
        private readonly ISafRepository _safRepository;
        private readonly IMessageBrokerRepository _messageBrokerRepository;
        private readonly IProviderUpdateRepository _providerUpdateRepository;

        public ProviderUpdateAppService(IMessageBrokerRepository messageBrokerRepository,
            ISafRepository safRepository,
            IProviderUpdateRepository providerUpdateRepository)
        {
            _messageBrokerRepository = messageBrokerRepository;
            _safRepository = safRepository;
            _providerUpdateRepository = providerUpdateRepository;
        }

        public async Task Execute(ProviderUpdateViewModel providerUpdateViewModel)
        {
            var userInfo = await _safRepository.GetUserInfo(providerUpdateViewModel.Login);

            await SetProviderInfo(providerUpdateViewModel);

            await NotifyProviderUpdate(providerUpdateViewModel, userInfo);
        }

        private async Task SetProviderInfo(ProviderUpdateViewModel providerUpdateViewModel)
        {
            var providerUpdate = _providerUpdateRepository.GetByLogin(providerUpdateViewModel.Login)
                            .OrderBy(p => p.CreationDate)
                            .LastOrDefault();

            if (providerUpdate is null)
            {
                providerUpdate = new()
                {
                    CreationDate = DateTime.UtcNow,
                    Email = providerUpdateViewModel.Email,
                    Login = providerUpdateViewModel.Login,
                    Phone = providerUpdateViewModel.Phone,
                    Status = ProviderUpdateStatusEnum.Pending,
                    Address = new()
                    {
                        City = providerUpdateViewModel.Address.City,
                        Number = providerUpdateViewModel.Address.Number,
                        State = providerUpdateViewModel.Address.State,
                        Street = providerUpdateViewModel.Address.Street,
                        ZipCode = providerUpdateViewModel.Address.ZipCode
                    }
                };

                await _providerUpdateRepository.Add(providerUpdate);
            }
            else
            {
                providerUpdate.ValidateAllowModification();

                providerUpdate.Email = providerUpdateViewModel.Email;
                providerUpdate.Login = providerUpdateViewModel.Login;
                providerUpdate.Phone = providerUpdateViewModel.Phone;
                providerUpdate.Address.City = providerUpdateViewModel.Address.City;
                providerUpdate.Address.Number = providerUpdateViewModel.Address.Number;
                providerUpdate.Address.State = providerUpdateViewModel.Address.State;
                providerUpdate.Address.Street = providerUpdateViewModel.Address.Street;
                providerUpdate.Address.ZipCode = providerUpdateViewModel.Address.ZipCode;

                await _providerUpdateRepository.Update(providerUpdate);
            }
        }

        private async Task NotifyProviderUpdate(ProviderUpdateViewModel providerUpdateViewModel, UserInfoModel userInfo)
        {
            var message = new
            {
                userInfo.CpfCnpj,
                providerUpdateViewModel.Phone,
                providerUpdateViewModel.Email,
                providerUpdateViewModel.Address,
                providerUpdateViewModel.Documents
            };

            await _messageBrokerRepository.PostTopicMessage(message, Constants.TopicName.ProviderUpdate);
        }
    }
}
