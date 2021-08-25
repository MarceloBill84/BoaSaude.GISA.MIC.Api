using System;

namespace BoaSaude.GISA.MIC.Domain.Models
{
	public class AttendanceModel
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int CompanyId { get; set; }
		public string Description { get; set; }
	}
}
