using BoaSaude.GISA.MIC.Domain.Enums;
using System;

namespace BoaSaude.GISA.MIC.Domain.Entities
{
	public class Manifestation
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string Login { get; set; }
		public int AttendanceId { get; set; }
		public ManifestationTypeEnum Type { get; set; }
		public string Description { get; set; }
	}
}
