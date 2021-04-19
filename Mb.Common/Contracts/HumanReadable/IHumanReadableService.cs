namespace Mb.Common.Contracts.Services.HumanReadable
{
	/// <summary>
	/// Performs conversions of various data types into a human readable format
	/// </summary>
	public interface IHumanReadableService
	{
		/// <summary>
		/// Converts various "date" data types into human readable format
		/// </summary>
		IHumanReadableDateTimeService DateTime { get; }

		/// <summary>
		/// Converts a number of bytes into a human readable format
		/// </summary>
		IBytesToHumanReadableService Bytes { get; }
	}
}
