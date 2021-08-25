using BoaSaude.GISA.MIC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Domain.Repositories
{
	public interface IPortalRepository
	{
		Task<IList<AttendanceModel>> Get(int companyId);
	}
}
