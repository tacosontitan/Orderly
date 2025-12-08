using Orderly.Core;
using Orderly.Orders.Contracts;

namespace Orderly.Fulfillment;

public class OrderConsumer(
	IMessageQueue<Order> orderQueue,
	ILogger<OrderConsumer> logger
) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			if (logger.IsEnabled(LogLevel.Information))
			{
				logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
			}
			await Task.Delay(1000, stoppingToken);
		}
	}
}
