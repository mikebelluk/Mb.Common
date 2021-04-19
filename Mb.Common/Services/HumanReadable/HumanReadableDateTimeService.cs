using System;
using Mb.Common.Contracts.Services.HumanReadable;

namespace Mb.Common.Services.HumanReadable
{
	/// <summary>
	/// Converts Date data types into a human readable format
	/// </summary>
	public class HumanReadableDateTimeService : IHumanReadableDateTimeService
	{
		/// <summary>
		/// Converts a <see cref="DateTimeOffset"/> into a human-readable form
		/// </summary>
		/// <param name="value">The <see cref="DateTimeOffset"/> to be converted</param>
		/// <returns>A human-readable representation</returns>
		public string AsReadable(DateTimeOffset value)
		{
			var timeSpan = new TimeSpan(DateTime.Now.Ticks - value.Ticks);
			return AsReadable(timeSpan);
		}

		/// <summary>
		/// Converts a <see cref="DateTime"/> into a human-readable form
		/// </summary>
		/// <param name="value">The <see cref="DateTime"/> to be converted</param>
		/// <returns>A human-readable representation</returns>
		public string AsReadable(DateTime value)
		{
			var timeSpan = new TimeSpan(DateTime.Now.Ticks - value.Ticks);
			return AsReadable(timeSpan);
		}

		/// <summary>
		/// Converts a <see cref="TimeSpan"/> into a human-readable form
		/// </summary>
		/// <param name="timeSpan">The <see cref="TimeSpan"/> to be converted</param>
		/// <returns>A human-readable representation</returns>
		public string AsReadable(TimeSpan timeSpan)
		{
			double delta = timeSpan.TotalSeconds;
			if (delta < 60)
				return timeSpan.Seconds == 1 ? "one second ago" : timeSpan.Seconds + " seconds ago";

			if (delta < 120)
				return "a minute ago";

			if (delta < 2700) // 45 * 60
				return timeSpan.Minutes + " minutes ago";

			if (delta < 5400) // 90 * 60
				return "an hour ago";

			if (delta < 86400) // 24 * 60 * 60
				return timeSpan.Hours + " hours ago";

			if (delta < 172800) // 48 * 60 * 60
				return "yesterday";

			if (delta < 2592000) // 30 * 24 * 60 * 60
				return timeSpan.Days + " days ago";

			if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
			{
				int months = Convert.ToInt32(Math.Floor((double)timeSpan.Days / 30));
				return months <= 1 ? "one month ago" : months + " months ago";
			}

			var years = Convert.ToInt32(Math.Floor((double)timeSpan.Days / 365));
			return years <= 1 ? "one year ago" : years + " years ago";
		}
	}
}
