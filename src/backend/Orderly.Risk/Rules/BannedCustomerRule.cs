using Orderly.Customers.Contracts;
using Orderly.Risk.Contracts;

namespace Orderly.Risk.Rules;

internal sealed class BannedCustomerRule(ICustomerService customerService) : IRiskRule
{
	/// <inheritdoc />
	public async Task<RiskResponse> Evaluate(RiskRequest request, CancellationToken cancellationToken)
	{
		Customer? customer = await customerService.GetCustomerById(request.CustomerId, cancellationToken);
		if (customer is null)
		{
			return RiskResponse.Reject(request.RequestId, 1.0, "Customer not found.");
		}

		if (customer.IsBanned)
		{
			return RiskResponse.Reject(request.RequestId, 1.0, "Customer is banned.");
		}

		return RiskResponse.Approve(request.RequestId);
	}
}