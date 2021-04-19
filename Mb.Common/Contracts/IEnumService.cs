using System;

namespace Mb.Common.Contracts
{
	/// <summary>
	/// Provides additional functionality for working with enums
	/// </summary>
	public interface IEnumService
	{
		/// <summary>
		/// Gets the previous value in the enum and will wrap around if necessary
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="src">The enum value</param>
		/// <returns>The previous value</returns>
		T Previous<T>(T src) where T : struct, IComparable, IConvertible, IFormattable;

		/// <summary>
		/// Gets the next value in the enum and will wrap around if necessary
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="src">The enum value</param>
		/// <returns>The next value</returns>
		T Next<T>(T src) where T : struct, IComparable, IConvertible, IFormattable;
	}
}
