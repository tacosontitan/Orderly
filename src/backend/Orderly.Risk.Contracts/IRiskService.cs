namespace Orderly.Risk.Contracts;

/// <summary>
/// Defines members for assessing risk.
/// </summary>
public interface IRiskService
{
	/// <summary>
	/// Evaluates the risk of a given request.
	/// </summary>
	/// <param name="request">The risk evaluation request details.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>The risk evaluation response.</returns>
	Task<RiskResponse> EvaluateRisk(RiskRequest request, CancellationToken cancellationToken);
}