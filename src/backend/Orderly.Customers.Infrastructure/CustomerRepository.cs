using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Orderly.Customers.Contracts;

namespace Orderly.Customers.Infrastructure;

/// <summary>
/// Represents a mock implementation of the customer repository.
/// </summary>
internal sealed class MockCustomerRepository(ILogger<MockCustomerRepository> logger) : ICustomerRepository
{
	private static readonly Random _random = new();
	private static readonly ImmutableArray<Customer> _customers =
	[
		new Customer(
				Guid.Parse("00000000-0000-0000-0000-000000000001"),
				"Alice Smith",
				"alice.smith@example.com",
				false
			),
		new Customer(
			Guid.Parse("00000000-0000-0000-0000-000000000002"),
			"Bob Johnson",
			"bob.johnson@example.com",
			true
		),
		new Customer(
			Guid.Parse("00000000-0000-0000-0000-000000000003"),
			"Charlie Brown",
			"charlie.brown@example.com",
			false
		)
,
	];

	/// <inheritdoc />
	public async Task<Customer?> GetCustomerById(Guid customerId, CancellationToken cancellationToken)
	{
		logger.LogDebug("Attempting to retrieve customer `{CustomerId}` from mock repository.", customerId);

		Stopwatch stopwatch = Stopwatch.StartNew();
		Customer? customer = _customers.FirstOrDefault(c => c.Id == customerId);
		await SimulateDelay(cancellationToken);

		stopwatch.Stop();
		logger.LogTrace("Operation completed in {ElapsedMilliseconds} ms.", stopwatch.ElapsedMilliseconds);
		return customer;
	}

	private static Task SimulateDelay(CancellationToken cancellationToken)
	{
		int delayInSeconds = _random.Next(1, 5);
		TimeSpan delay = TimeSpan.FromSeconds(delayInSeconds);
		return Task.Delay(delay, cancellationToken);
	}
}