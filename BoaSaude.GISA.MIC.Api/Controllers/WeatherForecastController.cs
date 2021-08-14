﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoaSaude.GISA.MIC.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}
	}
}
