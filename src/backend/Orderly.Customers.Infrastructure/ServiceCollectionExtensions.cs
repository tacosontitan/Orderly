using Microsoft.Extensions.DependencyInjection;
using Orderly.Customers.Contracts;

namespace Orderly.Customers.Infrastructure;

/// <summary>
/// Defines members for extending the service collection with customer infrastructure services.
/// </summary>
public static class ServiceCollectionExtensions
{
	extension(IServiceCollection services)
	{
		/// <summary>
		/// Adds customer services to the service collection.
		/// </summary>
		/// <param name="services">The service collection.</param>
		/// <returns>The updated service collection.</returns>
		public IServiceCollection AddCustomerInfrastructure()
		{
			services.AddSingleton<ICustomerRepository, MockCustomerRepository>();
			return services;
		}
	}
}