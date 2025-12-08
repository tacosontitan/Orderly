namespace Orderly.Core;

/// <summary>
/// Defines a mapping from one type to another.
/// </summary>
/// <typeparam name="TIn">Specifies the input type.</typeparam>
/// <typeparam name="TOut">Specifies the output type.</typeparam>
public interface IMapping<in TIn, out TOut>
{
	/// <summary>
	/// Maps an instance of <typeparamref name="TIn"/> to an instance of <typeparamref name="TOut"/>.
	/// </summary>
	/// <param name="input">The input instance to map from.</param>
	/// <returns>The mapped output instance.</returns>
	TOut Map(TIn input);
}