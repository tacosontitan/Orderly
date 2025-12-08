namespace Orderly.Orders.Contracts;

/// <summary>
/// Represents a request to evaluate an order.
/// </summary>
/// <param name="RequestId">The identifier of the request.</param>
/// <param name="CustomerId">The unique identifier of the customer placing the order.</param>
/// <param name="TotalCost">The total cost of the order.</param>
public sealed record OrderEvaluationRequest
(
	Guid RequestId,
	Guid CustomerId,
	decimal TotalCost
);