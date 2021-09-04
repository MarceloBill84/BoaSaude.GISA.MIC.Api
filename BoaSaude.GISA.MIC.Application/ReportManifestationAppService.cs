using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using BoaSaude.GISA.MIC.CrossCutting.Extensions;
using BoaSaude.GISA.MIC.Domain.Repositories;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Application
{
	public class ReportManifestationAppService : IReportManifestationAppService
	{
		private readonly IPortalRepository _portalRepository;
		private readonly ISafRepository _safRepository;
		private readonly IManifestationRepository _manifestationRepository;

		public ReportManifestationAppService(IPortalRepository portalRepository, ISafRepository safRepository,
				IManifestationRepository manifestationRepository)
		{
			_portalRepository = portalRepository;
			_safRepository = safRepository;
			_manifestationRepository = manifestationRepository;
		}

		public async Task<ReportManifestationViewModel> Execute(string login)
		{
			var beginDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1).AddMonths(-5);
			var endDate = DateTime.UtcNow.Date;

			var userInfo = await _safRepository.GetUserInfo(login);

			var attendance = await _portalRepository.Get(userInfo.CompanyId);
			var manifestations = _manifestationRepository.Get(attendance.Select(p => p.Id).ToList()).ToList();

			var report = new ReportManifestationViewModel();

			while (beginDate <= endDate)
			{
				report.Months.Add(beginDate.ToString(@"MMMM", new CultureInfo("PT-pt")).FirstCharToUpper());

				var attendanceReport = attendance.Where(p => p.Date.Month == beginDate.Month && p.Date.Year == beginDate.Year).ToList();
				report.Attendances.Add(attendanceReport.Count);
				report.Manifestations.Add(manifestations.Count(p => attendanceReport.Select(p => p.Id).Contains(p.AttendanceId)));

				beginDate = beginDate.AddMonths(1);
			}

			return report;
		}
	}
}
