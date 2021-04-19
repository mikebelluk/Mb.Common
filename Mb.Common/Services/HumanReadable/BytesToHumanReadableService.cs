using System;
using Mb.Common.Contracts.Services.HumanReadable;

namespace Mb.Common.Services.HumanReadable
{
	/// <summary>
	/// Converts a number of bytes into a human readable format
	/// </summary>
	public class BytesToHumanReadableService : IBytesToHumanReadableService
	{
		/// <summary>
		/// Converts the specified number of bytes into a human readable format
		/// </summary>
		/// <param name="sizeBytes">The size in bytes</param>
		/// <returns>The size in human readable format</returns>
		public string AsReadable(long sizeBytes)
		{
			string[] suffix = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB

			if (sizeBytes == 0)
				return "0" + suffix[0];

			long bytes = Math.Abs(sizeBytes);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			double num = Math.Round(bytes / Math.Pow(1024, place), 1);

			return $"{Math.Sign(sizeBytes) * num} {suffix[place]}";
		}
	}
}
