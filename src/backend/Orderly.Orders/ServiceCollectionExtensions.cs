using Microsoft.Extensions.DependencyInjection;
using Orderly.Orders.Contracts;
using Orderly.Orders.Infrastructure;

namespace Orderly.Orders;

/// <summary>
/// Defines members for extending the service collection with order infrastructure services.
/// </summary>
public static class ServiceCollectionExtensions
{
	extension(IServiceCollection services)
	{
		/// <summary>
		/// Adds order infrastructure services to the service collection.
		/// </summary>
		/// <returns>The updated service collection.</returns>
		public IServiceCollection AddOrderServices() => services
			.AddOrderInfrastructure()
			.AddScoped<IOrderService, OrderService>();
	}
}