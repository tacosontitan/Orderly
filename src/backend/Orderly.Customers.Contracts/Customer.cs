namespace Orderly.Customers.Contracts;

/// <summary>
/// Defines a customer entity.
/// </summary>
/// <param name="Id">The unique identifier of the customer.</param>
/// <param name="Name">The name of the customer.</param>
/// <param name="Email">The email address of the customer.</param>
/// <param name="IsBanned">Indicates whether the customer is banned.</param>
public sealed record Customer
(
	Guid Id,
	string Name,
	string Email,
	bool IsBanned
);