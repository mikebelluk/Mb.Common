namespace Mb.Common.Contracts
{
	/// <summary>
	/// A service used to convert bytes to different formats
	/// </summary>
	public interface IByteSizeService
	{
		#region Convert to Bytes

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

		#endregion Convert to Bytes

		#region Convert from Bytes

		/// <summary>
		/// Converts the specified number of bytes to KB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in KB</returns>
		double ToKB(long bytes);

		/// <summary>
		/// Converts the specified number of bytes to MB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in MB</returns>
		double ToMB(long bytes);

		/// <summary>
		/// Converts the specified number of bytes to GB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in GB</returns>
		double ToGB(long bytes);

		/// <summary>
		/// Converts the specified number of bytes to TB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in TB</returns>
		double ToTB(long bytes);

		#endregion Convert from Bytes
	}
}
