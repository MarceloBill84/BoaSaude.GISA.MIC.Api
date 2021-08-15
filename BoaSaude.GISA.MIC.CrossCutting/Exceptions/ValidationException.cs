using System;
using System.Net;

namespace BoaSaude.GISA.MIC.CrossCutting.Exceptions
{
	[Serializable]
	public class ValidationException : ExceptionBase
	{
		public ValidationException(string message) : base(HttpStatusCode.BadRequest, message)
		{

		}
	}
}
