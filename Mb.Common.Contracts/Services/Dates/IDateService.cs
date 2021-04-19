using System;

namespace Mb.Common.Contracts.Services.Dates
{
	/// <summary>
	/// Provides services for performing operations against various date/time classes
	/// </summary>
	public interface IDateService
	{
		#region Between

		/// <summary>
		/// Checks to see if a date falls between two dates
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/></param>
		/// <param name="startDate">The start <see cref="DateTime"/></param>
		/// <param name="endDate">The end <see cref="DateTime"/></param>
		/// <returns><c>true</c> if it falls between the date range; otherwise <c>false</c></returns>
		bool Between(DateTime date, DateTime startDate, DateTime endDate);

		/// <summary>
		/// Checks to see if a date falls between two dates
		/// </summary>
		/// <param name="date">The <see cref="DateTimeOffset"/></param>
		/// <param name="startDate">The start <see cref="DateTimeOffset"/></param>
		/// <param name="endDate">The end <see cref="DateTimeOffset"/></param>
		/// <returns><c>true</c> if it falls between the date range; otherwise <c>false</c></returns>
		bool Between(DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset endDate);

		#endregion Between

		#region ToAgeInYears

		/// <summary>
		/// Calculates an age
		/// </summary>
		/// <param name="dateTime">The start date, e.g. date of birth</param>
		/// <returns>The age in years</returns>
		int ToAgeInYears(DateTime dateTime);

		#endregion ToAgeInYears

		#region Working Days

		/// <summary>
		/// <para>
		/// Determines whether the date specified is a working day.
		/// </para>
		/// <param name="date">The <see cref="DateTime"/> to test</param>
		/// <returns>True if it's a working day, otherwise false</returns>
		bool IsWorkingDay(DateTime date);

		/// <summary>
		/// Determines whether the date specified is a (western) weekend day
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/> to test</param>
		/// <returns>True if falls on a weekend, otherwise false</returns>
		bool IsWeekend(DateTime date);

		/// <summary>
		/// Gets the next (western) working day, taking weekends into account
		/// </summary>
		/// <param name="date">The <see cref="DateTime"/></param>
		/// <returns>A <see cref="DateTime"/> for the next working days</returns>
		DateTime NextWorkday(DateTime date);

		#endregion Working Days
	}
}
