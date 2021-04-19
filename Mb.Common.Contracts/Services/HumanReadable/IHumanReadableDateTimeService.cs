using System;

namespace Mb.Common.Contracts.Services.HumanReadable
{
	/// <summary>
	/// Provides a means of accessing methods for conversions of types like <see cref="DateTime"/>,
	/// <see cref="DateTimeOffset"/> and <see cref="TimeSpan"/> to a human readable format
	/// </summary>
	public interface IHumanReadableDateTimeService
	{
		/// <summary>
		/// Converts a <see cref="DateTimeOffset"/> into a human-readable form
		/// </summary>
		/// <param name="value">The <see cref="DateTimeOffset"/> to be converted</param>
		/// <returns>A human-readable representation</returns>
		string AsReadable(DateTimeOffset value);

		/// <summary>
		/// Converts a <see cref="DateTime"/> into a human-readable form
		/// </summary>
		/// <param name="value">The <see cref="DateTime"/> to be converted</param>
		/// <returns>A human-readable representation</returns>
		string AsReadable(DateTime value);

		/// <summary>
		/// Converts a <see cref="TimeSpan"/> into a human-readable form
		/// </summary>
		/// <param name="timeSpan">The <see cref="TimeSpan"/> to be converted</param>
		/// <returns>A human-readable representation</returns>
		string AsReadable(TimeSpan timeSpan);
	}
}
