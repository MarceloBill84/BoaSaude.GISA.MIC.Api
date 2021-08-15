namespace BoaSaude.GISA.MIC.Domain.Models
{
	public class ApplicationConfig
	{
		public string JwtSecret { get; set; }
		public MessageBrokerConfig MessageBrokerConfig { get; set; }
	}
}
