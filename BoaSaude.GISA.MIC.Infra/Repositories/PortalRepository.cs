using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
	public class PortalRepository : IPortalRepository
	{
		public async Task<IList<AttendanceModel>> Get(int companyId)
		{
			var attendances = new List<AttendanceModel>();
			var random = new Random();

			for (int i = 0; i < 90; i++)
			{
				attendances.Add(new()
				{
					Id = i + 1,
					CompanyId = 1,
					Date = DateTime.UtcNow.AddMonths(random.Next(0, 6) * -1),
					Description = "Exame realizado"
				});
			}

			for (int i = 90; i <= 100; i++)
			{
				attendances.Add(new()
				{
					Id = i + 1,
					CompanyId = 2,
					Date = DateTime.UtcNow.AddMonths(random.Next(0, 6) * -1),
					Description = "Exame realizado"
				});
			}

			return attendances.Where(p => p.CompanyId == companyId).ToList();
		}
	}
}
