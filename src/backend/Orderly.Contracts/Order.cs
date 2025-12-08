namespace Orderly.Contracts;

/// <summary>
/// Represents an order placed by a customer.
/// </summary>
public sealed record Order
{
	/// <summary>
	/// The identifier of the request that initiated the order.
	/// </summary>
	public Guid RequestId { get; init; }

	/// <summary>
	/// The unique identifier of the customer placing the order.
	/// </summary>
	public Guid CustomerId { get; init; }

	/// <summary>
	/// The date and time when the order was created.
	/// </summary>
	public DateTimeOffset CreationDate { get; init; }

	/// <summary>
	/// The collection of item identifiers included in the order.
	/// </summary>
	public List<Guid> ItemIds { get; init; } = new();

	/// <summary>
	/// The total cost of the order the customer agreed to pay.
	/// </summary>
	public decimal TotalCost { get; init; }
}