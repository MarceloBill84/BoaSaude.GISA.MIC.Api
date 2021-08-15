using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BoaSaude.GISA.MIC.Application.ViewModels
{
	public class ProviderUpdateViewModel
	{
		[JsonIgnore]
		public string Login { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public ProviderAddressViewModel Address { get; set; }
		public IList<ProviderDocumentViewModel> Documents { get; set; }
	}
}
