using BoaSaude.GISA.MIC.Domain.Enums;
using System.Text.Json.Serialization;

namespace BoaSaude.GISA.MIC.Application.ViewModels
{
	public class RegisterManifestationViewModel
	{
		[JsonIgnore]
		public string Login { get; set; }
		public int AttendanceId { get; set; }
		public ManifestationTypeEnum Type { get; set; }
		public string Description { get; set; }
	}
}
