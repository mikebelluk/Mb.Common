using System.IO;
using System.Reflection;
using Mb.Common.Contracts.Services.IO;

namespace Mb.Common.Services.IO
{
	/// <summary>
	/// Provides functionality for working with the file system
	/// </summary>
	public class FileSystemService : IFileSystemService
	{
		#region GetApplicationPath

		/// <summary>
		/// Gets the directory that the application is running from
		/// </summary>
		/// <returns></returns>
		public string GetApplicationExecutingDirectory()
		{
			return GetAssemblyDirectory(null);
		}

		/// <summary>
		/// Gets the Directory of the specified assembly
		/// </summary>
		/// <param name="assembly">
		/// The <see cref="Assembly"/> to query or <c>null</c> to use the entry assembly
		/// </param>
		/// <returns>The directory where the assembly exists</returns>
		public string GetAssemblyDirectory(Assembly assembly = null)
		{
			if (assembly == null)
				assembly = Assembly.GetEntryAssembly();

			var filename =  Path.GetDirectoryName(assembly.Location);
			return Path.GetDirectoryName(filename);
		}

		#endregion
	}
}
