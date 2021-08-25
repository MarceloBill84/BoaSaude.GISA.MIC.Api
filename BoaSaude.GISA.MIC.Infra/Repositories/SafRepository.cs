using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
	public class SafRepository : ISafRepository
	{
		public async Task<UserInfoModel> GetUserInfo(string login)
		{
			return new()
			{
				CpfCnpj = "72617224058",
				Name = "Marcelo J. S.",
				CompanyId = 1,
				CompanyName = "Laborátorio Saúde em Dia"
			};
		}
	}
}
