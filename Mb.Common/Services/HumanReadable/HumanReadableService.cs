using System;
using Mb.Common.Contracts.Services.HumanReadable;

namespace Mb.Common.Services.HumanReadable
{
	/// <summary>
	/// Performs conversions of various data types into a human readable format
	/// </summary>
	public class HumanReadableService : IHumanReadableService
	{
		/// <summary>
		/// Provides a means of accessing methods for conversions of types like <see cref="DateTime"/>,
		/// <see cref="DateTimeOffset"/> and <see cref="TimeSpan"/> to a human readable format
		/// </summary>
		public IHumanReadableDateTimeService DateTime => new HumanReadableDateTimeService();

		public IBytesToHumanReadableService Bytes => new BytesToHumanReadableService();
	}
}
