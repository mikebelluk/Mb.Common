using System;
using System.Collections;
using System.Collections.Generic;
using Mb.Common.Extensions;
using Mb.Common.Helpers;
using Xunit;

namespace Mb.Common.Tests.Extensions
{
	public class DateTimeExtensionsTests
	{
		#region Between

		[Fact()]
		public void Between_ReturnsTrueForDateThatFallsBetweenTwoDates()
		{
			var date = new DateTime(2019, 12, 13, 19, 19, 36);
			var start = new DateTime(2019, 12, 1, 0, 0, 0);
			var end = new DateTime(2020, 1, 1, 0, 0, 0);

			Assert.True(date.Between(start, end));
		}

		[Fact()]
		public void Between_ReturnsFalseForDateThatDoesNotFallsBetweenTwoDates()
		{
			var date = new DateTime(2019, 11, 13, 19, 19, 36);
			var start = new DateTime(2019, 12, 1, 0, 0, 0);
			var end = new DateTime(2020, 1, 1, 0, 0, 0);

			Assert.False(date.Between(start, end));
		}

		#endregion

		#region ToAgeInYears

		[Fact()]
		public void ToAgeInYears_ReturnsCorrectAge()
		{
			var dateOfBirth = new DateTime(1900, 1, 1);
			var age = dateOfBirth.ToAgeInYears();

			Assert.Equal(DateTime.Now.Year - 1900, age);
		}

		#endregion

		#region ToReadableTime

		[Theory()]
		[InlineData(1, "one second ago")]
		[InlineData(5, "5 seconds ago")]
		[InlineData(60, "a minute ago")]
		[InlineData(119, "a minute ago")]
		[InlineData(120, "2 minutes ago")]
		[InlineData(5399, "an hour ago")]
		[InlineData(5400, "1 hours ago")]
		[InlineData(10800, "3 hours ago")]
		[InlineData(86399, "23 hours ago")]
		[InlineData(86400, "yesterday")]
		[InlineData(86401, "yesterday")]
		[InlineData(172800, "2 days ago")]
		[InlineData(2592000, "one month ago")]
		[InlineData(2592000 * 2, "2 months ago")]
		[InlineData(31104000, "one year ago")]
		public void ToReadableTime_TheoryReturnsCorrectValue(int secondsAgo, string expected)
		{
			var result = HumanReadableHelper.DateToHumanReadable(DateTime.Now.AddSeconds(secondsAgo * -1));
			Assert.Equal(expected, result);
		}

		#endregion

		#region Working Days

		[Theory]
		[InlineData(2020, 1, 1, true)]
		[InlineData(2020, 1, 2, true)]
		[InlineData(2020, 1, 3, true)]
		[InlineData(2020, 1, 4, false)]
		[InlineData(2020, 1, 5, false)]
		[InlineData(2020, 1, 6, true)]
		[InlineData(2020, 1, 7, true)]
		public void IsWorkingDay_TheoryReturnsCorrectResult(int year, int month, int day, bool expected)
		{
			var date = new DateTime(year, month, day);
			var actual = date.IsWorkingDay();

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(2020, 1, 1, false)]
		[InlineData(2020, 1, 2, false)]
		[InlineData(2020, 1, 3, false)]
		[InlineData(2020, 1, 4, true)]
		[InlineData(2020, 1, 5, true)]
		[InlineData(2020, 1, 6, false)]
		[InlineData(2020, 1, 7, false)]
		public void IsWeekend_TheoryReturnsCorrectResult(int year, int month, int day, bool expected)
		{
			var date = new DateTime(year, month, day);
			var actual = date.IsWeekend();

			Assert.Equal(expected, actual);
		}

		[Theory, ClassData(typeof(NextWorkingDayEnumerableTestData))]
		public void NextWorkday_TheoryReturnsCorrectResult(DateTime date, DateTime expected)
		{
			var actual = date.NextWorkday();

			Assert.Equal(expected.Date, actual.Date);
		}

		private class NextWorkingDayEnumerableTestData : IEnumerable<object[]>
		{
			private readonly List<object[]> _dates = new List<object[]>
			{
				new object[] { new DateTime(2020, 1, 1), new DateTime(2020, 1, 2) },
				new object[] { new DateTime(2020, 1, 2), new DateTime(2020, 1, 3) },
				new object[] { new DateTime(2020, 1, 3), new DateTime(2020, 1, 6) },
				new object[] { new DateTime(2020, 1, 4), new DateTime(2020, 1, 6) },
				new object[] { new DateTime(2020, 1, 5), new DateTime(2020, 1, 6) },
				new object[] { new DateTime(2020, 1, 6), new DateTime(2020, 1, 7) },
				new object[] { new DateTime(2020, 1, 7), new DateTime(2020, 1, 8) },
			};

			public IEnumerator<object[]> GetEnumerator()
			{
				return _dates.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		#endregion
	}
}
