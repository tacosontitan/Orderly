

using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Orderly.Orders.Contracts;

namespace Orderly.Orders.Infrastructure;

/// <summary>
/// Represents a gateway for evaluating orders by communicating with the risk service.
/// </summary>
/// <param name="httpClient">The HTTP client used to communicate with the risk service.</param>
/// <param name="logger">The logger for logging information and errors.</param>
internal sealed class OrderEvaluationGateway(
	HttpClient httpClient,
	ILogger<OrderEvaluationGateway> logger
) : IOrderEvaluationGateway
{
	/// <inheritdoc/>
	public async Task<OrderEvaluationResult> EvaluateOrder(OrderEvaluationRequest request, CancellationToken cancellationToken)
	{
		logger.LogDebug("Evaluating order `{RequestId}`.", request.RequestId);
		List<string> parameters = [
			$"requestId={request.RequestId}",
			$"customerId={request.CustomerId}",
			$"cost={request.TotalCost}"
		];

		string queryString = string.Join("&", parameters);
		string endpointUrl = $"risk?{queryString}";
		Stopwatch stopwatch = Stopwatch.StartNew();
		using var response = await httpClient.GetAsync(endpointUrl, cancellationToken);
		stopwatch.Stop();

		logger.LogTrace("Order `{RequestId}` evaluated in {ElapsedMilliseconds}ms with status code {StatusCode}.",
			request.RequestId,
			stopwatch.ElapsedMilliseconds,
			response.StatusCode
		);

		response.EnsureSuccessStatusCode();
		OrderEvaluationResult result = await response.Content.ReadFromJsonAsync<OrderEvaluationResult>(cancellationToken)
			?? throw new InvalidOperationException("Failed to deserialize order evaluation result.");

		return result;
	}
}