﻿using BoaSaude.GISA.MIC.Application.ViewModels;
using System.Threading.Tasks;

namespace BoaSaude.GISA.MIC.Application.Interfaces
{
	public interface IRegisterManifestationAppService
	{
		Task Execute(RegisterManifestationViewModel registerManifestationViewModel);
	}
}
