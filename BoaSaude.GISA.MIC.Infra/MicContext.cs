using BoaSaude.GISA.MIC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoaSaude.GISA.MIC.Infra
{
	public class MicContext : DbContext
	{
		public MicContext(DbContextOptions<MicContext> options) : base(options)
		{

		}
		public DbSet<ProviderUpdate> ProviderUpdate { get; set; }
		public DbSet<ProviderAddress> ProviderAddress { get; set; }
	}
}
