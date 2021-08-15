using BoaSaude.GISA.MIC.CrossCutting.Exceptions;
using BoaSaude.GISA.MIC.Domain.Enums;
using System;

namespace BoaSaude.GISA.MIC.Domain.Entities
{
	public class ProviderUpdate
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string Login { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public ProviderAddress Address { get; set; }
		public ProviderUpdateStatusEnum Status { get; set; }

		public void ValidateAllowModification()
		{
			if (Status != ProviderUpdateStatusEnum.Pending)
				throw new ValidationException("Não é possível atualizar os dados. Sua atualização já está completa ou em análise.");
		}
	}
}
