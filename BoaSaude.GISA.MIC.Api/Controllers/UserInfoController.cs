using BoaSaude.GISA.MIC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserInfoController : ControllerBase
	{
		private readonly ILogger<UserInfoController> _logger;
		private readonly IGetUserInfoAppService _getUserInfoAppService;

		public UserInfoController(ILogger<UserInfoController> logger,
			IGetUserInfoAppService getUserInfoAppService)
		{
			_logger = logger;
			_getUserInfoAppService = getUserInfoAppService;
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetUserInfo()
		{
			var login = HttpContext.User.Identity.Name;
			var info = await _getUserInfoAppService.Execute(login);
			return Ok(info);
		}
	}
}
