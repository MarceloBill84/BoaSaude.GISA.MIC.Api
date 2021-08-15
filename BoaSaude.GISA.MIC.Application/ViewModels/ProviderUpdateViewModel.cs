using System.Collections.Generic;

namespace BoaSaude.GISA.MIC.Application.ViewModels
{
	public class ProviderUpdateViewModel
	{
		public string Phone { get; set; }
		public IList<ProviderDocumentViewModel> Documents { get; set; }
	}
}
