namespace Orderly.Risk.Contracts;

/// <summary>
/// Defines a rule for evaluating risk.
/// </summary>
public interface IRiskRule
{
	/// <summary>
	/// Evaluates the risk request and returns a risk response.
	/// </summary>
	/// <param name="request">The risk request to evaluate.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>A risk response based on the evaluation.</returns>
	Task<RiskResponse> Evaluate(RiskRequest request, CancellationToken cancellationToken);
}