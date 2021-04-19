using System;
using Mb.Common.Contracts.Services.Dates;
using Mb.Common.Services.Dates;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// Useful extension methods for working with <see cref="DateTime"/> instances
	/// </summary>
	public static class DateTimeExtensions
	{
		#region Static Fields

		private static readonly IDateService _dateService = new DateService();

		#endregion

		#region Between

		/// <summary>
		/// Checks to see if a date falls between two dates
		/// </summary>
		/// <param name="dt">The <see cref="DateTime"/></param>
		/// <param name="startDate">The start <see cref="DateTime"/></param>
		/// <param name="endDate">The end <see cref="DateTime"/></param>
		/// <returns>True if it falls between the date range, otherwise false</returns>
		public static bool Between(this DateTime dt, DateTime startDate, DateTime endDate)
		{
			return _dateService.Between(dt, startDate, endDate);
		}

		#endregion

		#region ToAgeInYears

		/// <summary>
		/// Calculates an age
		/// </summary>
		/// <param name="dateTime">The start date, e.g. date of birth</param>
		/// <returns>The age in years</returns>
		public static int ToAgeInYears(this DateTime dateTime)
		{
			return _dateService.ToAgeInYears(dateTime);
		}

		#endregion

		#region Working Days

		/// <summary>
		/// <para>
		/// Determines whether the date specified is a working day.
		/// </para>
		///
		/// <para>
		/// NOTE: This is based on a western working week (Monday - Friday) and does not take into account
		/// local holidays.
		/// </para>
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/> to test</param>
		/// <returns>True if it's a working day, otherwise false</returns>
		public static bool IsWorkingDay(this DateTime date)
		{
			return _dateService.IsWorkingDay(date);
		}

		/// <summary>
		/// Determines whether the date specified is a (western) weekend day
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/> to test</param>
		/// <returns>True if falls on a weekend, otherwise false</returns>
		public static bool IsWeekend(this DateTime date)
		{
			return _dateService.IsWeekend(date);
		}

		/// <summary>
		/// Gets the next (western) working day, taking weekends into account
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/></param>
		/// <returns>A <see cref="DateTime"/> for the next working days</returns>
		public static DateTime NextWorkday(this DateTime date)
		{
			return _dateService.NextWorkday(date);
		}

		#endregion
	}
}
