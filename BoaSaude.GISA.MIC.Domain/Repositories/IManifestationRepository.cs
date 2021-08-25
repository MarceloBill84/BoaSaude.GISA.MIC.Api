using BoaSaude.GISA.MIC.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Domain.Repositories
{
	public interface IManifestationRepository
	{
		Task Add(Manifestation manifestation);
		IQueryable<Manifestation> Get(IList<int> attendanceIds);
	}
}
