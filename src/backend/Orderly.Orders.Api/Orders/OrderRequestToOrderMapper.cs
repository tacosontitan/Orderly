using Orderly.Contracts;
using Orderly.Core;

namespace Orderly.Api.Orders;

/// <summary>
/// Maps <see cref="OrderRequest"/> instances to <see cref="Order"/> instances.
/// </summary>
public sealed class OrderMapper : IMapper<OrderRequest, Order>
{
	/// <inheritdoc />
	public Order Map(OrderRequest source)
	{
		return new Order
		{
			RequestId = source.Id,
			CustomerId = source.CustomerId,
			CreationDate = DateTimeOffset.UtcNow,
			ItemIds = source.ItemIds,
			TotalCost = source.TotalCost
		};
	}
}