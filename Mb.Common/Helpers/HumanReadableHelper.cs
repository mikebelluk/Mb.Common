using System;

namespace Mb.Common.Helpers
{
	/// <summary>
	/// Helper methods that perform conversion into a human readable format
	/// </summary>
	public static class HumanReadableHelper
	{
		#region DateToHumanReadable

		/// <summary>
		/// Converts a <see cref="DateTime"/> into a human-readable form
		/// </summary>
		/// <param name="value">The <see cref="DateTime"/> to be converted</param>
		/// <returns>A human-readable representation of the date</returns>
		public static string DateToHumanReadable(DateTime value)
		{
			var ts = new TimeSpan(DateTime.Now.Ticks - value.Ticks);
			double delta = ts.TotalSeconds;
			if (delta < 60)
				return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

			if (delta < 120)
				return "a minute ago";

			if (delta < 2700) // 45 * 60
				return ts.Minutes + " minutes ago";

			if (delta < 5400) // 90 * 60
				return "an hour ago";

			if (delta < 86400) // 24 * 60 * 60
				return ts.Hours + " hours ago";

			if (delta < 172800) // 48 * 60 * 60
				return "yesterday";

			if (delta < 2592000) // 30 * 24 * 60 * 60
				return ts.Days + " days ago";

			if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
			{
				int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
				return months <= 1 ? "one month ago" : months + " months ago";
			}

			var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
			return years <= 1 ? "one year ago" : years + " years ago";
		}

		#endregion

		#region BytesToHumanReadableSize

		/// <summary>
		/// Converts the specified number of bytes into a human readable format
		/// </summary>
		/// <param name="sizeBytes">The size in bytes</param>
		/// <returns>The size in human readable format</returns>
		public static string BytesToHumanReadableSize(long sizeBytes)
		{
			string[] suffix = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB

			if (sizeBytes == 0)
				return "0" + suffix[0];

			long bytes = Math.Abs(sizeBytes);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			double num = Math.Round(bytes / Math.Pow(1024, place), 1);

			return $"{Math.Sign(sizeBytes) * num} {suffix[place]}";
		}

		#endregion
	}
}
