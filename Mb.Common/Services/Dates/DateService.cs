using System;
using System.Globalization;
using Mb.Common.Contracts.Services.Dates;

namespace Mb.Common.Services.Dates
{
	/// <summary>
	/// Provides services for performing operations against various date/time classes
	/// </summary>
	public class DateService : IDateService
	{
		#region Fields

		private readonly int _weekendLengthDays = 2;

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public DateService()
		{ }

		/// <summary>
		/// Constructor that allows the length of the weekend to be specified
		/// </summary>
		/// <param name="weekendLengthDays">The length of the weekend in days</param>
		public DateService(int weekendLengthDays)
		{
			_weekendLengthDays = weekendLengthDays;
		}

		#endregion

		#region Between

		/// <summary>
		/// Checks to see if a date falls between two dates
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/></param>
		/// <param name="startDate">The start <see cref="DateTime"/></param>
		/// <param name="endDate">The end <see cref="DateTime"/></param>
		/// <returns><c>true</c> if it falls between the date range; otherwise <c>false</c></returns>
		public bool Between(DateTime date, DateTime startDate, DateTime endDate)
		{
			return date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks;
		}

		/// <summary>
		/// Checks to see if a date falls between two dates
		/// </summary>
		/// <param name="date">The <see cref="DateTimeOffset"/></param>
		/// <param name="startDate">The start <see cref="DateTimeOffset"/></param>
		/// <param name="endDate">The end <see cref="DateTimeOffset"/></param>
		/// <returns><c>true</c> if it falls between the date range; otherwise <c>false</c></returns>
		public bool Between(DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset endDate)
		{
			return date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks;
		}

		#endregion Between

		#region ToAgeInYears

		/// <summary>
		/// Calculates an age
		/// </summary>
		/// <param name="dateTime">The start date, e.g. date of birth</param>
		/// <returns>The age in years</returns>
		public int ToAgeInYears(DateTime dateTime)
		{
			var age = DateTime.Now.Year - dateTime.Year;
			if (DateTime.Now < dateTime.AddYears(age))
				age--;

			return age;
		}

		#endregion

		#region Working Days

		/// <summary>
		/// <para>
		/// Determines whether the date specified is a working day.
		/// </para>
		/// <param name="date">The <see cref="DateTime"/> to test</param>
		/// <returns>True if it's a working day, otherwise false</returns>
		public bool IsWorkingDay(DateTime date)
		{
			return !IsWeekend(date);
		}

		/// <summary>
		/// Determines whether the date specified is a (western) weekend day
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/> to test</param>
		/// <returns>True if falls on a weekend, otherwise false</returns>
		public bool IsWeekend(DateTime date)
		{
			var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
			var firstDayOfWeek = dateTimeFormat.FirstDayOfWeek;
			var lastDayOfWeek = (DayOfWeek)7 - _weekendLengthDays;

			return (int)date.DayOfWeek != (int)firstDayOfWeek && (int)date.DayOfWeek != (int)lastDayOfWeek;
		}

		/// <summary>
		/// Gets the next (western) working day, taking weekends into account
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/></param>
		/// <returns>A <see cref="DateTime"/> for the next working days</returns>
		public DateTime NextWorkday(DateTime date)
		{
			var nextDay = date.AddDays(1);

			while (!IsWorkingDay(nextDay))
			{
				nextDay = nextDay.AddDays(1);
			}

			return nextDay;
		}

		#endregion
	}
}
