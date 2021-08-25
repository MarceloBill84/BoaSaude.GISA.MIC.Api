using System.Collections.Generic;

namespace BoaSaude.GISA.MIC.Application.ViewModels
{
	public class ReportManifestationViewModel
	{
		public IList<string> Months { get; set; } = new List<string>();
		public IList<int> Attendances { get; set; } = new List<int>();
		public IList<int> Manifestations { get; set; } = new List<int>();
	}
}
