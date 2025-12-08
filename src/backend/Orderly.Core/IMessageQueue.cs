namespace Orderly.Core;

/// <summary>
/// Defines members for a generic message queue.
/// </summary>
/// <typeparam name="T">The type of messages stored in the queue.</typeparam>
public interface IMessageQueue<T>
{
	/// <summary>
	/// Enqueues a message to the queue.
	/// </summary>
	/// <param name="message">The message to enqueue.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>A task that represents the asynchronous enqueue operation.</returns>
	public Task Enqueue(T message, CancellationToken cancellationToken);

	/// <summary>
	/// Dequeues a message from the queue.
	/// </summary>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>The dequeued message.</returns>
	public Task<T> Dequeue(CancellationToken cancellationToken);
}