using System;
using System.Collections.Generic;
using System.Linq;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// A collection of miscellaneous extensions
	/// </summary>
	public static class LinqExtensions
	{
		#region IsIn

		/// <summary>
		/// <para>
		/// Similar to the T-SQL IN operator in that it allows you to check whether a specified value exists in a list
		/// </para>
		/// <para>
		/// Author: Winston Smith
		/// Source: https://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=1&tab=votes#tab-top
		/// </para>
		/// </summary>
		/// <typeparam name="T">The source type</typeparam>
		/// <param name="source">The value to be tested</param>
		/// <param name="list">The list of values which will be tested to see if it contains the source value</param>
		/// <returns>True if source exists in the list of values, otherwise false</returns>
		public static bool IsIn<T>(this T source, params T[] list)
		{
			if (null == source)
				throw new ArgumentNullException(nameof(source));

			return list.Contains(source);
		}

		#endregion

		#region IsNullOrEmpty 

		/// <summary>
		/// <para>
		/// Determines whether an <see cref="IEnumerable{T}"/> is null or empty
		/// </para>
		/// <para>
		/// Author: Pure.Krome
		/// Source: https://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
		/// </para>
		/// </summary>
		/// <typeparam name="T">The type</typeparam>
		/// <param name="enumerable">The <see cref="IEnumerable{T}"/> to test</param>
		/// <returns>True if the <see cref="IEnumerable{T}"/> is null or empty, otherwise false</returns>
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable == null ||
				   !enumerable.Any();
		}

		#endregion

		#region ToDelimitedString

		/// <summary>
		/// <para>
		/// Converts an <see cref="IEnumerable{T}"/> to a delimited list
		/// </para>
		/// <para>
		/// Author: Kenny Eliasson
		/// Source: https://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
		/// </para>
		/// </summary>
		/// <typeparam name="T">The type</typeparam>
		/// <param name="items">The values to be joined into a delimited list</param>
		/// <param name="func">The function to select the values to be joined</param>
		/// <param name="delimiter">The delimiter</param>
		/// <returns>The delimited list as a string</returns>
		public static string ToDelimitedString<T>(this IEnumerable<T> items, Func<T, string> func, string delimiter)
		{
			return string.Join(delimiter, items.Select(func).ToArray());
		}

		#endregion
	}
}
