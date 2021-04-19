using System.Reflection;

namespace Mb.Common.Contracts.Services.IO
{
	/// <summary>
	/// Provides functionality for working with the file system
	/// </summary>
	public interface IFileSystemService
	{
		/// <summary>
		/// Gets the directory that the application is running from
		/// </summary>
		/// <returns></returns>
		string GetApplicationExecutingDirectory();

		/// <summary>
		/// Gets the Directory of the specified assembly
		/// </summary>
		/// <param name="assembly">
		/// The <see cref="Assembly"/> to query or <c>null</c> to use the entry assembly
		/// </param>
		/// <returns>The directory where the assembly exists</returns>
		string GetAssemblyDirectory(Assembly assembly = null);
	}
}
