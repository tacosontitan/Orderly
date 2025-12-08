namespace Orderly.Customers.Contracts;

/// <summary>
/// Defines members for customer repository operations.
/// </summary>
public interface ICustomerRepository
{
	/// <summary>
	/// Retrieves a customer by their unique identifier.
	/// </summary>
	/// <param name="customerId">The unique identifier of the customer.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>The customer entity if found; otherwise, null.</returns>
	Task<Customer?> GetCustomerById(Guid customerId, CancellationToken cancellationToken);
}