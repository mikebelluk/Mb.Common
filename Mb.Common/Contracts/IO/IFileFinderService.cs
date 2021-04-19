using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mb.Common.Contracts.Services.IO
{
	/// <summary>
	/// Uses a fluent API to provide functionality for finding files based on set criteria
	/// </summary>
	public interface IFileFinderService
	{
		/// <summary>
		/// Sets the base path to search under
		/// </summary>
		/// <param name="path">The path</param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		IFileFinderService FileFileUnderPath(string path);

		/// <summary>
		/// Limits search results to files with a specified extension, e.g. <c>.*</c>; <c>.txt</c>; <c>.json</c>
		/// </summary>
		/// <param name="extension">The file extension, which defaults to all files <c>.*</c></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		IFileFinderService WithExtension(string extension = ".*");

		/// <summary>
		/// Limits search results to files with the specified extensions, e.g. <c>.*</c>; <c>.txt</c>; <c>.json</c>
		/// </summary>
		/// <param name="extensions">An <see cref="IEnumerable{String}"/> of file extensions</param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		IFileFinderService WithExtensions(IEnumerable<string> extensions);

		/// <summary>
		/// Limits the search results to files of a minimum size in bytes (inclusive)
		/// </summary>
		/// <param name="minimumSizeBytes"></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		IFileFinderService WithMinimumSizeBytes(long minimumSizeBytes);

		/// <summary>
		/// Limits the search results to files of a maximum size in bytes (inclusive)
		/// </summary>
		/// <param name="maximumSizeBytes"></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		IFileFinderService WithMaximumSizeBytes(long maximumSizeBytes);

		/// <summary>
		/// Allows you to specify the maximum number of results to return
		/// </summary>
		/// <param name="maximumSearchResults">The maximum number of results to return. Defaults to <c>long.MaxValue</c></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		IFileFinderService SetMaximumResults(int maximumSearchResults);

		/// <summary>
		/// Finds all files that match the specified criteria
		/// </summary>
		/// <returns>An <see cref="IQueryable{FileInfo}"/> containing the search results</returns>
		IQueryable<FileInfo> Find();

		/// <summary>
		/// Finds the specified files
		/// </summary>
		/// <param name="orderByAction">A <see cref="Func{T, TResult}"/></param>
		/// <param name="isOrderByAscending"></param>
		/// <returns>An <see cref="IQueryable{FileInfo}"/> containing the search results</returns>
		IQueryable<FileInfo> Find<TKey>(Func<FileInfo, TKey> orderByAction, bool isOrderByAscending);
	}
}
