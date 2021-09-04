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
		}
	}
}
