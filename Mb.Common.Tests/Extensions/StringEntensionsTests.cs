using System;
using Mb.Common.Extensions;
using Xunit;

namespace Mb.Common.Tests.Extensions
{
	public class StringEntensionsTests
	{
		#region EqualsIgnoreCase

		[Theory()]
		[InlineData("Hello World!", "Hello World!", true)]
		[InlineData("Hello world!", "hello world!", true)]
		[InlineData("Hello world!", "abc", false)]
		public void EqualsIgnoreCase_TheoryReturnsCorrectValue(string a, string b, bool expected)
		{
			var actual = a.EqualsIgnoreCase(b);
			Assert.Equal(expected, actual);
		}

		#endregion

		#region Testing for and converting to numeric data types

		[Theory()]
		[InlineData("123", true)]
		[InlineData("123.45", false)]
		[InlineData("abc", false)]
		public void IsInteger_TheoryReturnsCorrectValue(string input, bool expected)
		{
			var actual = input.IsInteger();

			Assert.Equal(expected, actual);
		}

		[Theory()]
		[InlineData("123", true)]
		[InlineData("123.45", true)]
		[InlineData("abc", false)]
		public void IsDouble_TheoryReturnsCorrectValue(string input, bool expected)
		{
			var actual = input.IsDouble();

			Assert.Equal(expected, actual);
		}

		[Theory()]
		[InlineData("123", true)]
		[InlineData("123.45", true)]
		[InlineData("abc", false)]
		public void IsDecimal_TheoryReturnsCorrectValue(string input, bool expected)
		{
			var actual = input.IsDecimal();

			Assert.Equal(expected, actual);
		}

		[Theory()]
		[InlineData("123", 0, 123)]
		[InlineData("123.45", 0, 0)]
		[InlineData("abc", 0, 0)]
		public void ToInteger_TheoryReturnsCorrectValue(string input, int defaultValue, int expected)
		{
			var actual = input.ToInteger(defaultValue);

			Assert.Equal(expected, actual);
		}

		[Theory()]
		[InlineData("123", 0, 123)]
		[InlineData("123.45", 0, 123.45)]
		[InlineData("abc", 0, 0)]
		public void ToDouble_TheoryReturnsCorrectValue(string input, double defaultValue, double expected)
		{
			var actual = input.ToDouble(defaultValue);

			Assert.Equal(expected, actual);
		}

		[Theory()]
		[InlineData("123", 0, 123)]
		[InlineData("123.45", 0, 123.45)]
		[InlineData("abc", 0, 0)]
		public void ToDecimal_TheoryReturnsCorrectValue(string input, decimal defaultValue, decimal expected)
		{
			var actual = input.ToDecimal(defaultValue);

			Assert.Equal(expected, actual);
		}

		#endregion

		#region MatchesWildcard

		[Theory]
		[InlineData("Abc", "A*", StringComparison.OrdinalIgnoreCase, true)]
		[InlineData("Abc", "a*", StringComparison.OrdinalIgnoreCase, true)]
		[InlineData("Abc", "a*", StringComparison.Ordinal, false)]
		[InlineData("Abc", "A*c", StringComparison.OrdinalIgnoreCase, true)]
		[InlineData("Abc", "Ab*", StringComparison.OrdinalIgnoreCase, true)]
		[InlineData("Abc", "*bc", StringComparison.OrdinalIgnoreCase, true)]
		public void MatchesWildcard_TheoryReturnsCorrectResult(string text, string pattern,
			StringComparison comparisonType, bool expected)
		{
			var actual = text.MatchesWildcard(pattern, comparisonType);
			Assert.Equal(expected, actual);
		}

		#endregion
	}
}
