using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Application
{
	public class GetUserInfoAppService : IGetUserInfoAppService
	{
		private readonly ISafRepository _safRepository;

		public GetUserInfoAppService(ISafRepository safRepository)
		{
			_safRepository = safRepository;
		}

		public async Task<UserInfoViewModel> Execute(string login)
		{
			var model = await _safRepository.GetUserInfo(login);

			return new()
			{
				Name = model.Name,
				CompanyName = model.Company
			};
		}
	}
}
