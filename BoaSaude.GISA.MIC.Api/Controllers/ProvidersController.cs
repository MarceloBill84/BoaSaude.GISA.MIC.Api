using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProvidersController : ControllerBase
	{
		private readonly IProviderUpdateAppService _providerUpdateAppService;

		public ProvidersController(IProviderUpdateAppService providerUpdateAppService)
		{
			_providerUpdateAppService = providerUpdateAppService;
		}

		[Authorize(Roles = "Provider")]
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] ProviderUpdateViewModel providerUpdateViewModel)
		{
			providerUpdateViewModel.Login = HttpContext.User.Identity.Name;
			await _providerUpdateAppService.Execute(providerUpdateViewModel);
			return NoContent();
		}
	}
}
