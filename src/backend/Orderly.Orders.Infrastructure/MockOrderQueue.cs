using System.Collections.Concurrent;
using Orderly.Core;
using Orderly.Orders.Contracts;

namespace Orderly.Orders.Infrastructure;

/// <summary>
/// An in-memory message queue for orders.
/// </summary>
internal sealed class MockOrderQueue : IMessageQueue<Order>
{
	private readonly ConcurrentQueue<Order> _queue = new();
	private readonly SemaphoreSlim _signal = new(0);

	/// <inheritdoc/>
	public async Task Enqueue(Order item, CancellationToken cancellationToken)
	{
		_queue.Enqueue(item);
		_signal.Release();
		await Task.CompletedTask;
	}

	/// <inheritdoc/>
	public async Task<Order> Dequeue(CancellationToken cancellationToken)
	{
		await _signal.WaitAsync(cancellationToken);
		_queue.TryDequeue(out var item);
		return item!;
	}
}