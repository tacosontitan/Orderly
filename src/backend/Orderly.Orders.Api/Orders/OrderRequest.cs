namespace Orderly.Api.Orders;

/// <summary>
/// Represents a request to place an order.
/// </summary>
public sealed record OrderRequest
{
	/// <summary>
	/// The identifier of the request that initiated the order.
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// The unique identifier of the customer placing the order.
	/// </summary>
	public Guid CustomerId { get; init; }

	/// <summary>
	/// The collection of item identifiers included in the order.
	/// </summary>
	public List<Guid> ItemIds { get; init; } = new();

	/// <summary>
	/// The total cost of the order the customer agreed to pay.
	/// </summary>
	public decimal TotalCost { get; init; }
}