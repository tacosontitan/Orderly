using Amazon.SQS;
using Microsoft.Extensions.Options;
using Orderly.Contracts;
using Orderly.Core;

namespace Orderly.Api.Orders;

/// <summary>
/// Represents a service responsible for processing orders.
/// </summary>
/// <param name="httpClient">The HTTP client used for making requests.</param>
/// <param name="sqsClient">The Amazon SQS client used for interacting with SQS.</param>
/// <param name="orderMapper">The mapper for converting order requests to orders.</param>
/// <param name="options">The options monitor for order processing configuration.</param>
/// <param name="logger">The logger instance for logging.</param>
public sealed class OrderProcessingService(
	HttpClient httpClient,
	IAmazonSQS sqsClient,
	IMapper<OrderRequest, Order> orderMapper,
	IOptionsMonitor<OrderProcessingOptions> options,
	ILogger<OrderProcessingService> logger
)
{
	public async Task<Guid> ProcessOrder(OrderRequest request)
	{
		logger.LogDebug("Processing order request {RequestId} for customer {CustomerId}", request.Id, request.CustomerId);
	}
}