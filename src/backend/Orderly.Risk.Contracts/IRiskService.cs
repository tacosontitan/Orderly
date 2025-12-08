namespace Orderly.Risk.Contracts;

/// <summary>
/// Defines members for assessing risk.
/// </summary>
public interface IRiskService
{
	Task<RiskResponse> EvaluateRisk(RiskRequest request);
}