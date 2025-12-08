namespace Orderly.Risk.Contracts;

/// <summary>
/// Defines a response from a risk assessment.
/// </summary>
/// <param name="RequestId">The identifier for the request that was assessed.</param>
/// <param name="IsApproved">Indicates whether the order was approved.</param>
/// <param name="Score">The risk score assigned to the order.</param>
/// <param name="Reason">The reason for the approval or rejection, if any.</param>
public sealed record RiskResponse
(
	Guid RequestId,
	bool IsApproved,
	double Score,
	string? Reason
)
{
	/// <summary>
	/// Creates an approved risk response with a default score of 0.0.
	/// </summary>
	/// <param name="requestId">The identifier for the request that was assessed.</param>
	/// <returns>An approved risk response.</returns>
	public static RiskResponse Approve(Guid requestId) =>
		new(requestId, true, 0.0, null);

	/// <summary>
	/// Creates an approved risk response.
	/// </summary>
	/// <param name="requestId">The identifier for the request that was assessed.</param>
	/// <param name="score">The risk score assigned to the order.</param>
	public static RiskResponse Approve(Guid requestId, double score) =>
		new(requestId, true, score, null);

	/// <summary>
	/// Creates a rejected risk response.
	/// </summary>
	/// <param name="requestId">The identifier for the request that was assessed.</param>
	/// <param name="score">The risk score assigned to the order.</param>
	/// <param name="reason">The reason for the rejection.</param>
	public static RiskResponse Reject(Guid requestId, double score, string reason) =>
		new(requestId, false, score, reason);
}