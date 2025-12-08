using Orderly.Customers.Contracts;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Orderly.Customers;

/// <summary>
/// Represents a service for managing customers.
/// </summary>
/// <param name="customerRepository">The customer repository.</param>
/// <param name="logger">The logger instance.</param>
internal sealed class CustomerService(
	ICustomerRepository customerRepository,
	ILogger<CustomerService> logger
) : ICustomerService
{
	/// <inheritdoc />
	public async Task<Customer?> GetCustomerById(Guid customerId, CancellationToken cancellationToken)
	{
		logger.LogDebug("Retrieving customer `{CustomerId}`.", customerId);
		Customer? customer = await customerRepository.GetCustomerById(customerId, cancellationToken);
		if (customer is null)
		{
			logger.LogWarning("Customer `{CustomerId}` not found.", customerId);
		}

		return customer;
	}
}