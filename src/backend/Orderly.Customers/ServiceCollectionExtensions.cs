using Microsoft.Extensions.DependencyInjection;
using Orderly.Customers.Contracts;
using Orderly.Customers.Infrastructure;

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
		public IServiceCollection AddCustomerServices() => services
			.AddCustomerInfrastructure()
			.AddScoped<ICustomerService, CustomerService>();
	}
}