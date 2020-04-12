using System;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// A collection of useful extension methods for strings
	/// </summary>
	public static class StringEntensions
	{
		#region EqualsIgnoreCase

		/// <summary>
		/// Checks two strings to see if they are equal, ignoring case
		/// </summary>
		/// <param name="a">The first string</param>
		/// <param name="b">The second string</param>
		/// <returns>True if they are equal, otherwise false</returns>
		public static bool EqualsIgnoreCase(this string a, string b)
		{
			return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
		}

		#endregion

		#region Testing for and converting to numeric data types

		/// <summary>
		/// Determines whether a string is an integer
		/// </summary>
		/// <param name="input">The string to test</param>
		/// <returns>True if the string is an integer, otherwise false</returns>
		public static bool IsInteger(this string input)
		{
			return int.TryParse(input, out _);
		}

		/// <summary>
		/// Determines whether a string is a double
		/// </summary>
		/// <param name="input">The string to test</param>
		/// <returns>True if the string is an double, otherwise false</returns>
		public static bool IsDouble(this string input)
		{
			return decimal.TryParse(input, out _);
		}

		/// <summary>
		/// Determines whether a string is a decimal
		/// </summary>
		/// <param name="input">The string to test</param>
		/// <returns>True if the string is an decimal, otherwise false</returns>
		public static bool IsDecimal(this string input)
		{
			return decimal.TryParse(input, out _);
		}

		/// <summary>
		/// Converts a string to an integer, using a default value if the conversion fails
		/// </summary>
		/// <param name="input">The string to convert</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The converted value</returns>
		public static int ToInteger(this string input, int defaultValue)
		{
			return (int.TryParse(input, out int temp)) ? temp : defaultValue;
		}

		/// <summary>
		/// Converts a string to an double, using a default value if the conversion fails
		/// </summary>
		/// <param name="input">The string to convert</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The converted value</returns>
		public static double ToDouble(this string input, double defaultValue)
		{
			return (double.TryParse(input, out double temp)) ? temp : defaultValue;
		}

		/// <summary>
		/// Converts a string to an decimal, using a default value if the conversion fails
		/// </summary>
		/// <param name="input">The string to convert</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The converted value</returns>
		public static decimal ToDecimal(this string input, decimal defaultValue)
		{
			return (decimal.TryParse(input, out decimal temp)) ? temp : defaultValue;
		}

		#endregion

		#region MatchesWildcard

		/// <summary>
		/// Checks to see if a string matches a wildcard pattern
		/// Source: https://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow/3527407#3527407
		/// </summary>
		/// <param name="text">The string to check</param>
		/// <param name="pattern">The wildcard pattern</param>
		/// <param name="comparison"></param>
		/// <returns>True if the text matches the pattern, otherwise false</returns>
		public static bool MatchesWildcard(this string text, string pattern,
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
		{
			if (comparisonType.IsIn(
				StringComparison.OrdinalIgnoreCase,
				StringComparison.CurrentCultureIgnoreCase,
				StringComparison.InvariantCultureIgnoreCase))
			{
				text = text.ToLower();
				pattern = pattern.ToLower();
			}

			int it = 0;
			while (text.CharAt(it) != 0 && pattern.CharAt(it) != '*')
			{
				if (pattern.CharAt(it) != text.CharAt(it) && pattern.CharAt(it) != '?')
					return false;
				it++;
			}

			int cp = 0;
			int mp = 0;
			int ip = it;

			while (text.CharAt(it) != 0)
			{
				if (pattern.CharAt(ip) == '*')
				{
					if (pattern.CharAt(++ip) == 0)
						return true;
					mp = ip;
					cp = it + 1;
				}
				else if (pattern.CharAt(ip) == text.CharAt(it) || pattern.CharAt(ip) == '?')
				{
					ip++;
					it++;
				}
				else
				{
					ip = mp;
					it = cp++;
				}
			}

			while (pattern.CharAt(ip) == '*')
			{
				ip++;
			}
			return pattern.CharAt(ip) == 0;
		}

		/// <summary>
		/// Returns the character at the specified index in the string
		/// </summary>
		/// <param name="s">The input string</param>
		/// <param name="index">The index</param>
		/// <returns>The character at the specified index</returns>
		public static char CharAt(this string s, int index)
		{
			if (index < s.Length)
				return s[index];

			return '\0';
		}

		#endregion
	}
}
