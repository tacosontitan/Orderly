using Microsoft.Extensions.DependencyInjection;
using Orderly.Core;
using Orderly.Orders.Contracts;

namespace Orderly.Orders.Infrastructure;

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
		public IServiceCollection AddOrderInfrastructure() => services
			.AddSingleton<IMessageQueue<Order>, MockOrderQueue>()
			.AddSingleton<IOrderRepository, MockOrderRepository>()
			.AddSingleton<IOrderEvaluationGateway, OrderEvaluationGateway>();
	}
}