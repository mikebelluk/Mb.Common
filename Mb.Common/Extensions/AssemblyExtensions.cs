using System.Reflection;
using Mb.Common.Helpers;

namespace Mb.Common.Extensions
{
	/// <summary>
	/// A collection of useful extension methods for working with assemblies
	/// </summary>
	public static class AssemblyExtensions
	{
		/// <summary>
		/// Gets the directory for the specified assembly
		/// </summary>
		/// <param name="assembly">The assembly</param>
		/// <returns>The directory</returns>
		public static string GetDirectory(this Assembly assembly)
		{
			return FileSystemHelper.GetApplicationPath(assembly);
		}
	}
}
