using BoaSaude.GISA.MIC.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Domain.Repositories
{
	public interface IProviderUpdateRepository
	{
		IQueryable<ProviderUpdate> GetByLogin(string login);
		Task Add(ProviderUpdate providerUpdate);
		Task Update(ProviderUpdate providerUpdate);
	}
}
