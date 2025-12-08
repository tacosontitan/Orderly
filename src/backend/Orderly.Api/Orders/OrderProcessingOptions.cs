namespace Orderly.Api.Orders;

/// <summary>
/// Defines members that configure order processing behavior.
/// </summary>
public sealed record OrderProcessingOptions
{
	/// <summary>
	/// The URL of the SQS queue to which order messages will be sent.
	/// </summary>
	public required string SqsQueueUrl { get; init; }
}