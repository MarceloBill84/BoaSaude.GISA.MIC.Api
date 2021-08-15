using BoaSaude.GISA.MIC.Application;
using BoaSaude.GISA.MIC.Application.Interfaces;
using BoaSaude.GISA.MIC.Domain.Repositories;
using BoaSaude.GISA.MIC.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoaSaude.GISA.MIC.IoC
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection RegisterRepositories(this IServiceCollection services)
		{
			services.AddScoped<ISafRepository, SafRepository>()
				.AddScoped<IMessageBrokerRepository, MessageBrokerRepository>();

			return services;
		}

		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			return services;
		}

		public static IServiceCollection RegisterAppServices(this IServiceCollection services)
		{
			services.AddScoped<IGetUserInfoAppService, GetUserInfoAppService>()
				.AddScoped<IProviderUpdateAppService, ProviderUpdateAppService>();
			return services;
		}
	}
}
