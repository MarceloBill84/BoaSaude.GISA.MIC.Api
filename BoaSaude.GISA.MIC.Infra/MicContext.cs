using Microsoft.EntityFrameworkCore;

namespace BoaSaude.GISA.MIC.Infra
{
	public class MicContext : DbContext
	{
		public MicContext(DbContextOptions<MicContext> options) : base(options)
		{

		}
	}
}
