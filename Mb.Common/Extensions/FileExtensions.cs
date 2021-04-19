using System.IO;
using Mb.Common.Contracts.Services.HumanReadable;
using Mb.Common.Services;
using Mb.Common.Services.HumanReadable;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// Useful extensions for working with Files
	/// </summary>
	public static class FileExtensions
	{
		#region Static Fields

		private static readonly IHumanReadableService _humanReadable = new HumanReadableService();

		#endregion

		#region ToHumanReadableFileSize

		/// <summary>
		/// Returns the size of a file in human-readable format
		/// </summary>
		/// <param name="file">The <see cref="FileInfo"/></param>
		/// <returns>The file size in human readable format</returns>
		public static string ToHumanReadableFileSize(this FileInfo file)
		{
			return _humanReadable.Bytes.AsReadable(file.Length);
		}

		#endregion
	}
}
