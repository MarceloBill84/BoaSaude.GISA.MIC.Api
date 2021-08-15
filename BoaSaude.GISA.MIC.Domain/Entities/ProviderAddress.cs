namespace BoaSaude.GISA.MIC.Domain.Entities
{
	public class ProviderAddress
	{
		public int Id { get; set; }
		public int ProviderUpdateId { get; set; }
		public int ZipCode { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}
}
