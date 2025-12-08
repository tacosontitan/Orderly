namespace Orderly.Orders.Contracts;

/// <summary>
/// Defines members for order management services.
/// </summary>
public interface IOrderService
{
	/// <summary>
	/// Places a new order.
	/// </summary>
	/// <param name="request">The order request details.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	Task PlaceOrder(OrderRequest request, CancellationToken cancellationToken);
}