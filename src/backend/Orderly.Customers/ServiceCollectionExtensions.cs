using Microsoft.Extensions.DependencyInjection;
using Orderly.Customers.Contracts;

namespace Orderly.Customers;

/// <summary>
/// Defines members for extending the service collection with customer services.
/// </summary>
public static class ServiceCollectionExtensions
{
	extension(IServiceCollection services)
	{
		/// <summary>
		/// Adds customer services to the service collection.
		/// </summary>
		/// <returns>The updated service collection.</returns>
		public IServiceCollection AddCustomerServices()
		{
			services.AddTransient<ICustomerService, CustomerService>();
			return services;
		}
	}
}