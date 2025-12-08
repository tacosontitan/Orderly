namespace Orderly.Orders.Contracts;

public sealed record OrderRequest
(
	Guid Id,
	Guid CustomerId,
	decimal TotalCost,
	List<Guid> ItemIds
);