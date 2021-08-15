using BoaSaude.GISA.MIC.Domain.Entities;
using BoaSaude.GISA.MIC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
	public class ProviderUpdateRepository : IProviderUpdateRepository
	{
		private readonly DbSet<ProviderUpdate> _dbProviderUpdate;
		private readonly MicContext _micContext;

		public ProviderUpdateRepository(DbSet<ProviderUpdate> dbProviderUpdate, MicContext micContext)
		{
			_dbProviderUpdate = dbProviderUpdate;
			_micContext = micContext;
		}

		public IQueryable<ProviderUpdate> GetByLogin(string login)
		{
			return _dbProviderUpdate.Where(p => p.Login == login);
		}

		public async Task Add(ProviderUpdate providerUpdate)
		{
			await _dbProviderUpdate.AddAsync(providerUpdate);
			await _micContext.SaveChangesAsync();
		}

		public void Update(ProviderUpdate providerUpdate)
		{
			_dbProviderUpdate.Update(providerUpdate);
		}
	}
}
