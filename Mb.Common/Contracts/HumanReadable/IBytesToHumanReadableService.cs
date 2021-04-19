namespace Mb.Common.Contracts.Services.HumanReadable
{
	/// <summary>
	/// Converts a number of bytes into a human readable format
	/// </summary>
	public interface IBytesToHumanReadableService
	{
		/// <summary>
		/// Converts the specified number of bytes into a human readable format
		/// </summary>
		/// <param name="sizeBytes">The size in bytes</param>
		/// <returns>The size in human readable format</returns>
		string AsReadable(long sizeBytes);
	}
}
