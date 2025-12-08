using Orderly.Risk.Contracts;

namespace Orderly.Risk.Rules;

internal sealed class BannedCustomerRule : IRiskRule
{
	private static readonly HashSet<Guid> BannedCustomers = new()
	{
		Guid.Parse("11111111-1111-1111-1111-111111111111"),
		Guid.Parse("22222222-2222-2222-2222-222222222222"),
		Guid.Parse("33333333-3333-3333-3333-333333333333")
	};

	/// <inheritdoc />
	public RiskResponse Evaluate(RiskRequest request)
	{
		if (BannedCustomers.Contains(request.CustomerId))
		{
			return RiskResponse.Reject(request.RequestId, 1.0, "Customer is banned.");
		}

		return RiskResponse.Approve(request.RequestId);
	}
}