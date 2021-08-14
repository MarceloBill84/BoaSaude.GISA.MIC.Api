using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
	public class SafRepository : ISafRepository
	{
		public async Task<UserInfoModel> GetUserInfo(string login)
		{
			return new UserInfoModel
			{
				Name = "Marcelo J. S.",
				Company = "Laborátorio Saúde em Dia"
			};
		}
	}
}
