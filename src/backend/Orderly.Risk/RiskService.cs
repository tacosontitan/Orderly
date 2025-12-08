using System.Text;
using Orderly.Risk.Contracts;

namespace Orderly.Risk;

/// <summary>
/// Represents a service that evaluates risk based on a set of risk rules.
/// </summary>
public sealed class RiskService(IEnumerable<IRiskRule> riskRules) : IRiskService
{
	/// <summary>
	/// Evaluates the risk of a given request by applying all registered risk rules.
	/// </summary>
	/// <param name="request">The risk assessment request.</param>
	/// <returns>
	///     A task that represents the asynchronous operation and contains the risk assessment response.
	/// </returns>
	public async Task<RiskResponse> EvaluateRisk(RiskRequest request, CancellationToken cancellationToken)
	{
		int rulesFailed = 0;
		double totalRiskScore = 0;
		StringBuilder rejectionReasons = new();
		foreach (IRiskRule rule in riskRules)
		{
			RiskResponse result = await rule.Evaluate(request, cancellationToken);
			if (!result.IsApproved)
			{
				rulesFailed++;
				totalRiskScore += result.Score;
				rejectionReasons.AppendLine(result.Reason);
			}
		}

		bool isApproved = rejectionReasons.Length == 0;
		string finalReason = isApproved ? "Approved" : rejectionReasons.ToString().TrimEnd();
		double averageRiskScore = rulesFailed > 0 ? totalRiskScore / rulesFailed : 0;
		return new(request.RequestId, isApproved, averageRiskScore, finalReason);
	}
}