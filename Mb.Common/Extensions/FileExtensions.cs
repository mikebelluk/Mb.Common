using System.IO;
using Mb.Common.Helpers;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// Useful extensions for working with Files
	/// </summary>
	public static class FileExtensions
	{
		#region ToHumanReadableFileSize

		/// <summary>
		/// Returns the size of a file in human-readable format
		/// </summary>
		/// <param name="file">The <see cref="FileInfo"/></param>
		/// <returns>The file size in human readable format</returns>
		public static string ToHumanReadableFileSize(this FileInfo file)
		{
			return HumanReadableHelper.BytesToHumanReadableSize(file.Length);
		}

		#endregion
	}
}
