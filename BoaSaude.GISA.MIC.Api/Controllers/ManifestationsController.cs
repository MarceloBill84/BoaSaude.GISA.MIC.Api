using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ManifestationsController : ControllerBase
	{
		private readonly IRegisterManifestationAppService _registerManifestationAppService;

		public ManifestationsController(IRegisterManifestationAppService registerManifestationAppService)
		{
			_registerManifestationAppService = registerManifestationAppService;
		}


		[Authorize(Roles = "Partnered")]
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] RegisterManifestationViewModel registerManifestationViewModel)
		{
			registerManifestationViewModel.Login = HttpContext.User.Identity.Name;
			await _registerManifestationAppService.Execute(registerManifestationViewModel);
			return NoContent();
		}
	}
}
