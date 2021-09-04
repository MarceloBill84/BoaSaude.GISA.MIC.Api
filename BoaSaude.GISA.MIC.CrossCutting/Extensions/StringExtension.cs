using System.Linq;

namespace BoaSaude.GISA.MIC.CrossCutting.Extensions
{
	public static class StringExtension
	{
		public static string FirstCharToUpper(this string input)
		{
			return input.First().ToString().ToUpper() + input.Substring(1);
		}
	}
}
