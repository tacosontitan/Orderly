namespace Orderly.Orders.Contracts;

/// <summary>
/// Defines members for evaluating orders through a gateway.
public interface IOrderEvaluationGateway
{
	/// <summary>
	/// Evaluates an order based on the provided request.
	/// </summary>
	/// <param name="request">The order evaluation request.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>The result of the order evaluation.</returns>
	Task<OrderEvaluationResult> EvaluateOrder(OrderEvaluationRequest request, CancellationToken cancellationToken);
}