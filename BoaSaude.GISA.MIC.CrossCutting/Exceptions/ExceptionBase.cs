using System;
using System.Net;

namespace BoaSaude.GISA.MIC.CrossCutting.Exceptions
{
	public class ExceptionBase : Exception
	{
		private readonly HttpStatusCode _httpStatusCode;
		public ExceptionBase(HttpStatusCode httpStatusCode, string message) : base(message)
		{
			_httpStatusCode = httpStatusCode;
		}

		public HttpStatusCode StatusCode => _httpStatusCode;
	}
}
