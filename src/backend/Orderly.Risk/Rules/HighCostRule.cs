using Orderly.Risk.Contracts;

namespace Orderly.Risk.Rules;

/// <summary>
/// Defines a rule that flags high-cost requests as high risk.
/// </summary>
internal sealed class HighCostRule : IRiskRule
{
	private const decimal HighCostThreshold = 10000m;

	/// <inheritdoc />
	public async Task<RiskResponse> Evaluate(RiskRequest request, CancellationToken cancellationToken)
	{
		if (request.TotalCost > HighCostThreshold)
		{
			return RiskResponse.Reject(request.RequestId, 0.9, "Request exceeds high-cost threshold.");
		}

		return RiskResponse.Approve(request.RequestId);
	}
}