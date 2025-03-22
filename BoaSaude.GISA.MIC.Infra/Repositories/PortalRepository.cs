using BoaSaude.GISA.MIC.Domain.Models;
using BoaSaude.GISA.MIC.Domain.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Infra.Repositories
{
    /// <summary>
    /// Esta classe representa um mock para a api do portal
    /// </summary>
    public class PortalRepository : IPortalRepository
    {
        public async Task<IList<AttendanceModel>> Get(int companyId)
        {
            var attendances = GetAttendances();

            return attendances.Where(p => p.CompanyId == companyId).ToList();
        }

        private static IList<AttendanceModel> GetAttendances()
        {
            using StreamReader r = new("attendance.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<AttendanceModel>>(json);
        }
    }
}
