using BoaSaude.GISA.MIC.Domain.Models;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Domain.Repositories
{
	public interface ISafRepository
	{
		Task<UserInfoModel> GetUserInfo();
	}
}
