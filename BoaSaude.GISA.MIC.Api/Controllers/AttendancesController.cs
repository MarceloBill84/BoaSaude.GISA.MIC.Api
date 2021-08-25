using BoaSaude.GISA.MIC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AttendancesController : ControllerBase
	{
		private readonly IReportManifestationAppService _reportManifestationAppService;

		public AttendancesController(IReportManifestationAppService reportManifestationAppService)
		{
			_reportManifestationAppService = reportManifestationAppService;
		}

		[Authorize(Roles = "Provider")]
		[HttpGet("manifestations")]
		public async Task<IActionResult> Get()
		{
			var response = await _reportManifestationAppService.Execute(HttpContext.User.Identity.Name);
			return Ok(response);
			/*return Ok(new
			{
				Months = new[] { "Março", "Abril", "Maio", "Junho", "Julho", "Agosto" },
				Attendances = new[] { 15, 10, 12, 16, 18, 13 },
				Manifestations = new[] { 5, 2, 3, 2, 4, 1 }
			});*/
		}
	}
}
