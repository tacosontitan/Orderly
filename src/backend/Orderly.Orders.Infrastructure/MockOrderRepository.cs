using System.Collections.Concurrent;
using Orderly.Orders.Contracts;

namespace Orderly.Orders.Infrastructure;

internal sealed class MockOrderRepository : IOrderRepository
{
	private readonly ConcurrentDictionary<Guid, Order> _orders = new();

	public Task<Order> Create(OrderRequest request, CancellationToken cancellationToken)
	{
		Order newOrder = new()
		{
			RequestId = request.Id,
			CustomerId = request.CustomerId,
			TotalCost = request.TotalCost,
			Status = OrderStatus.Pending
		};

		if (!_orders.TryAdd(newOrder.RequestId, newOrder))
		{
			throw new InvalidOperationException("Order with the same ID already exists.");
		}

		return Task.FromResult(newOrder);
	}

	public Task UpdateStatus(Guid requestId, OrderStatus status, CancellationToken cancellationToken)
	{
		if (_orders.TryGetValue(requestId, out var order))
		{
			var updatedOrder = order with { Status = status };
			_orders[requestId] = updatedOrder;
		}

		return Task.CompletedTask;
	}

	public Task<Order?> GetById(Guid requestId, CancellationToken cancellationToken)
	{
		_orders.TryGetValue(requestId, out var order);
		return Task.FromResult(order);
	}
}