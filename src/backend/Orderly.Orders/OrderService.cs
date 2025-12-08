using Microsoft.Extensions.Logging;
using Orderly.Core;
using Orderly.Orders.Contracts;

namespace Orderly.Orders;

internal sealed class OrderService(
	IOrderRepository orderRepository,
	IOrderEvaluationGateway orderEvaluationGateway,
	IMessageQueue<Order> orderQueue,
	ILogger<OrderService> logger
) : IOrderService
{
	/// <inheritdoc/>
	public async Task PlaceOrder(OrderRequest request, CancellationToken cancellationToken)
	{
		logger.LogDebug("Attempting to place order `{RequestId}` for customer `{CustomerId}`.",
			request.Id,
			request.CustomerId
		);

		await EvaluateOrder(request, cancellationToken);

		// Persist the order and send it off for fulfillment.
		Order order = await orderRepository.Create(request, cancellationToken);
		await orderQueue.Enqueue(order, cancellationToken);
	}

	private async Task EvaluateOrder(OrderRequest request, CancellationToken cancellationToken)
	{
		OrderEvaluationRequest evaluationRequest = new(request.Id, request.CustomerId, request.TotalCost);
		OrderEvaluationResult evaluationResult = await orderEvaluationGateway.EvaluateOrder(evaluationRequest, cancellationToken);
		if (!evaluationResult.IsAccepted)
		{
			logger.LogWarning("Order `{RequestId}` for customer `{CustomerId}` was rejected: {Reason}.",
				request.Id,
				request.CustomerId,
				evaluationResult.Reason
			);

			throw new InvalidOperationException($"Order was rejected. {evaluationResult.Reason}");
		}

		logger.LogInformation("Order `{RequestId}` for customer `{CustomerId}` was accepted.",
			request.Id,
			request.CustomerId
		);
	}
}