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

		#region Convert to Bytes

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

		#endregion Convert to Bytes

		#region Convert from Bytes

		/// <summary>
		/// Converts the specified number of bytes to KB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in KB</returns>
		public double ToKB(long bytes)
		{
			return OneKB / bytes;
		}

		/// <summary>
		/// Converts the specified number of bytes to MB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in MB</returns>
		public double ToMB(long bytes)
		{
			return OneMB / bytes;
		}

		/// <summary>
		/// Converts the specified number of bytes to GB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in GB</returns>
		public double ToGB(long bytes)
		{
			return OneGB / bytes;
		}

		/// <summary>
		/// Converts the specified number of bytes to TB
		/// </summary>
		/// <param name="bytes">The number of bytes to convert</param>
		/// <returns>The value in TB</returns>
		public double ToTB(long bytes)
		{
			return OneTB / bytes;
		}

		#endregion Convert from Bytes
	}
}
