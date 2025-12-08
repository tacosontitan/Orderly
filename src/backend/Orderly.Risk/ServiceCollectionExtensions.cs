using Microsoft.Extensions.DependencyInjection;
using Orderly.Risk.Contracts;
using Orderly.Risk.Rules;

namespace Orderly.Risk;

/// <summary>
/// Defines members for extending the service collection with risk services.
/// </summary>
public static class ServiceCollectionExtensions
{
	extension(IServiceCollection services)
	{
		/// <summary>
		/// Adds risk services and rules to the service collection.
		/// </summary>
		/// <returns>The updated service collection.</returns>
		public IServiceCollection AddRiskServices()
		{
			services.AddTransient<IRiskService, RiskService>();
			services.AddTransient<IRiskRule, HighCostRule>();
			services.AddTransient<IRiskRule, BannedCustomerRule>();
			return services;
		}
	}
}