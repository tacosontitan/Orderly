namespace Orderly.Orders.Contracts;

/// <summary>
/// Represents the result from an order evaluation.
/// </summary>
/// <param name="RequestId">The identifier of the request.</param>
/// <param name="IsAccepted">Indicates whether the order is accepted.</param>
/// <param name="Reason">The reason for rejection if the order is not accepted; otherwise, null.</param>
public sealed record OrderEvaluationResult
(
	Guid RequestId,
	bool IsAccepted,
	string? Reason
);