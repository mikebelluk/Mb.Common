using System.Collections;
using System.Collections.Generic;
using Mb.Common.Extensions;
using Xunit;

namespace Mb.Common.Tests.Extensions
{
	public class LinqExtensionsTests
	{
		#region IsIn

		[Theory()]
		[InlineData(1, true, 5, 7, 1, 9)]
		[InlineData(2, false, 5, 7, 1, 9)]
		[InlineData("cat", true, "the", "cat", "sat", "on", "the", "mat")]
		[InlineData("dog", false, "the", "cat", "sat", "on", "the", "mat")]
		public void IsIn_TheoryReturnsCorrectValue(object source, bool expected, params object[] list)
		{
			var actual = source.IsIn(list);

			Assert.Equal(expected, actual);
		}

		#endregion

		#region IsNullOrEmpty

		[Theory, ClassData(typeof(IsNullOrEmptyEnumerableTestData))]
		public void IsNullOrEmpty_TheoryReturnsCorrectValue<T>(IEnumerable<T> enumerable, bool expected)
		{
			var actual = enumerable.IsNullOrEmpty();

			Assert.Equal(expected, actual);
		}

		private class IsNullOrEmptyEnumerableTestData : IEnumerable<object[]>
		{
			private readonly List<object[]> _items = new List<object[]>
			{
				new object[] { null, true },
				new object[] { new List<int>(), true },
				new object[] { new List<int> { 1, 2, 3 }, false }
			};

			public IEnumerator<object[]> GetEnumerator()
			{
				return _items.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<object[]>)_items).GetEnumerator();
			}
		}

		#endregion

		#region ToDelimitedString

		[Fact()]
		public void ToDelimitedString_ReturnsCorrectValueForListOfStrings()
		{
			var list = new List<string>
			{
				"Bread",
				"Milk",
				"Cheese"
			};

			var expected = "Bread, Milk, Cheese";
			var actual = list.ToDelimitedString(l => l, ", ");

			Assert.Equal(expected, actual);
		}

		[Fact()]
		public void ToDelimitedString_ReturnsCorrectValueForListOfObjects()
		{
			var list = new[]
			{
				new { Item = "Bread", Quantity = 1 },
				new { Item = "Milk", Quantity = 1 },
				new { Item = "Cheese", Quantity = 1 },
			};

			var expected = "Bread, Milk, Cheese";
			var actual = list.ToDelimitedString(l => l.Item, ", ");

			Assert.Equal(expected, actual);
		}

		#endregion
	}
}
