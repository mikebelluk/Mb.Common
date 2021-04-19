using System.Reflection;
using Mb.Common.Contracts.Services.IO;
using Mb.Common.Services.IO;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// A collection of useful extension methods for working with assemblies
	/// </summary>
	public static class AssemblyExtensions
	{
		#region Static Fields

		private static readonly IFileSystemService _fileSystemService = new FileSystemService();

		#endregion

		/// <summary>
		/// Gets the directory for the specified assembly
		/// </summary>
		/// <param name="assembly">The assembly</param>
		/// <returns>The directory</returns>
		public static string GetDirectory(this Assembly assembly)
		{
			return _fileSystemService.GetAssemblyDirectory(assembly);
		}
	}
}
