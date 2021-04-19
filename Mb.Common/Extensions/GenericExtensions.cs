using System;

namespace Mb.Common.Extensions
{
	public static class GenericExtensions
	{
		#region ThrowIfNull

		/// <summary>
		/// <para>
		/// Throws an ArgumentNullException if the given data item is null.
		/// </para>
		/// <para>
		/// Author: Jon Skeet
		/// Source: https://jonskeet.uk/csharp/miscutil/
		/// </para>
		/// </summary>
		/// <param name="data">The item to check for nullity.</param>
		/// <param name="name">The name to use when throwing an exception, if necessary</param>
		public static void ThrowIfNull<T>(this T data, string name = null, string message = null) where T : class
		{
			if (data == null)
				throw new ArgumentNullException(name, message);
		}

		#endregion
	}
}
