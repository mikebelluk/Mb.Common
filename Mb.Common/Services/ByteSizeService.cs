using Mb.Common.Contracts;

namespace Mb.Common.Services
{
	/// <summary>
	/// A service used to convert bytes to different formats
	/// </summary>
	public class ByteSizeService : IByteSizeService
	{
		#region Constants

		private const long OneKB = 1024;
		private const long OneMB = OneKB * 1024;
		private const long OneGB = OneMB * 1024;
		private const long OneTB = OneGB * 1024;

		#endregion

		#region Conversion

		/// <summary>
		/// Converts bytes to KB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The KB</returns>
		public long AsKB(long bytes)
		{
			return bytes * OneKB;
		}

		/// <summary>
		/// Converts bytes to MB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The MB</returns>
		public long AsMB(long bytes)
		{
			return bytes * OneMB;
		}

		/// <summary>
		/// Converts bytes to GB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The GB</returns>
		public long AsGB(long bytes)
		{
			return bytes * OneGB;
		}

		/// <summary>
		/// Converts bytes to TB
		/// </summary>
		/// <param name="bytes">The number of bytes</param>
		/// <returns>The TB</returns>
		public long AsTB(long bytes)
		{
			return bytes * OneTB;
		}

		#endregion
	}
}
