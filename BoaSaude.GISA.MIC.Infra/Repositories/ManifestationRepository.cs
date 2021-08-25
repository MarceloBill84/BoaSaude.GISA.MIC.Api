using BoaSaude.GISA.MIC.Domain.Entities;
using BoaSaude.GISA.MIC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
	public class ManifestationRepository : IManifestationRepository
	{
		private readonly DbSet<Manifestation> _dbManifestation;
		private readonly MicContext _micContext;

		public ManifestationRepository(MicContext micContext)
		{
			_micContext = micContext;
			_dbManifestation = _micContext.Manifestation;
		}

		public async Task Add(Manifestation manifestation)
		{
			await _dbManifestation.AddAsync(manifestation);
			await _micContext.SaveChangesAsync();
		}

		public IQueryable<Manifestation> Get(IList<int> attendanceIds)
		{
			return _dbManifestation.Where(p => attendanceIds.Contains(p.AttendanceId));
		}
	}
}
