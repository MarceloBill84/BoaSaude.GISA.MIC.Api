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

		public UserInfoController(ILogger<UserInfoController> logger)
		{
			_logger = logger;
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetUserInfo()
		{
			return Ok();
		}
	}
}
