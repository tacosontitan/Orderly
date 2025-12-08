namespace Orderly.Orders.Contracts;

public interface IOrderRepository
{
	Task<Order> Create(OrderRequest request, CancellationToken cancellationToken);

	Task UpdateStatus(Guid requestId, OrderStatus status, CancellationToken cancellationToken);

	Task<Order?> GetById(Guid requestId, CancellationToken cancellationToken);
}