using System;
using System.IO;
using System.Reflection;

namespace Mb.Common.Helpers
{
	/// <summary>
	/// Helper methods for working with the file system
	/// </summary>
	public static class FileSystemHelper
	{
		#region GetApplicationPath

		/// <summary>
		/// Gets the path for the current application
		/// </summary>
		/// <returns>The path to the application's executable directory</returns>
		public static string GetApplicationPath()
		{
			return GetApplicationPath(Assembly.GetExecutingAssembly());
		}

		/// <summary>
		/// Gets the path for the current application
		/// </summary>
		/// <returns>The path to the application's executable directory</returns>
		internal static string GetApplicationPath(Assembly assembly)
		{
			var codeBase = assembly.CodeBase;
			var uri = new UriBuilder(codeBase);
			var path = Uri.UnescapeDataString(uri.Path);
			return Path.GetDirectoryName(path);
		}

		#endregion
	}
}
