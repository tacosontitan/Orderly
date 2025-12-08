namespace Orderly.Risk.Contracts;

/// <summary>
/// Defines a request to assess risk.
/// </summary>
/// <param name="RequestId">The identifier for the request being evaluated.</param>
/// <param name="CustomerId">The identifier for the customer that initiated the request.</param>
/// <param name="TotalCost">The total cost associated with the request.</param>
public sealed record RiskRequest
(
    Guid RequestId,
    Guid CustomerId,
    decimal TotalCost
);