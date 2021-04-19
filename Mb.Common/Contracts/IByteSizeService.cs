namespace Mb.Common.Contracts
{
	/// <summary>
	/// A service used to convert bytes to different formats
	/// </summary>
	public interface IByteSizeService
	{
		/// <summary>
		/// Converts bytes to KB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The KB</returns>
		long AsKB(long bytes);

		/// <summary>
		/// Converts bytes to MB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The MB</returns>
		long AsMB(long bytes);

		/// <summary>
		/// Converts bytes to GB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The GB</returns>
		long AsGB(long bytes);

		/// <summary>
		/// Converts bytes to TB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The TB</returns>
		long AsTB(long bytes);
	}
}
