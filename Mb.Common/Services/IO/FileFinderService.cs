using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mb.Common.Contracts.Services.IO;

namespace Mb.Common.Services.IO
{
	/// <summary>
	/// Uses a fluent API to provide functionality for finding files based on set criteria
	/// </summary>
	public class FileFinderService : IFileFinderService
	{
		#region Fields

		private string _path;
		private List<string> _extensions;
		private long _minimumSizeBytes;
		private long _maximumSizeBytes;
		private int _maximumSearchResults;
		private SearchOption _searchOption;

		#endregion

		/// <summary>
		/// Default constructor
		/// </summary>
		public FileFinderService()
		{
			_extensions = new List<string>();
			_maximumSearchResults = int.MaxValue;
		}

		/// <summary>
		/// Sets the base path to search under
		/// </summary>
		/// <param name="path">The path</param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService FileFileUnderPath(string path)
		{
			if (!Directory.Exists(path))
				throw new DirectoryNotFoundException($"The directory \"{path}\" was not found!");

			_path = path;
			return this;
		}

		/// <summary>
		/// Limits search results to files with a specified extension, e.g. <c>.*</c>; <c>.txt</c>; <c>.json</c>
		/// </summary>
		/// <param name="extension">The file extension
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService WithExtension(string extension)
		{
			if (string.IsNullOrEmpty(extension))
				throw new ArgumentNullException(nameof(extension));

			_extensions.Add(extension);
			return this;
		}

		/// <summary>
		/// Limits search results to files with the specified extensions, e.g. <c>.*</c>; <c>.txt</c>; <c>.json</c>
		/// </summary>
		/// <param name="extensions">An <see cref="IEnumerable{String}"/> of file extensions</param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService WithExtensions(IEnumerable<string> extensions)
		{
			if (extensions?.Any() != true)
				throw new ArgumentNullException(nameof(extensions));

			_extensions.AddRange(extensions);

			return this;
		}

		/// <summary>
		/// Limits the search results to files of a minimum size in bytes (inclusive)
		/// </summary>
		/// <param name="minimumSizeBytes"></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService WithMinimumSizeBytes(long minimumSizeBytes)
		{
			if (minimumSizeBytes < 1)
				throw new ArgumentOutOfRangeException(nameof(minimumSizeBytes), "You must specify at least 1 byte");

			_minimumSizeBytes = minimumSizeBytes;

			return this;
		}

		/// <summary>
		/// Limits the search results to files of a maximum size in bytes (inclusive)
		/// </summary>
		/// <param name="maximumSizeBytes"></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService WithMaximumSizeBytes(long maximumSizeBytes)
		{
			if (maximumSizeBytes < 1)
				throw new ArgumentOutOfRangeException(nameof(_maximumSizeBytes), "You must specify at least 1 byte");

			_maximumSizeBytes = maximumSizeBytes;

			return this;
		}

		/// <summary>
		/// Allows you to specify the maximum number of results to return
		/// </summary>
		/// <param name="maximumSearchResults">The maximum number of results to return. Defaults to <c>long.MaxValue</c></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService SetMaximumResults(int maximumSearchResults)
		{
			if (maximumSearchResults < 1)
				throw new ArgumentOutOfRangeException(nameof(maximumSearchResults), "You must specify at least 1 search result");

			_maximumSearchResults = maximumSearchResults;

			return this;
		}

		/// <summary>
		/// Allows you to specify the <see cref="SearchOption"/>
		/// </summary>
		/// <param name="searchOption">The <see cref="SearchOption searchOption"/></param>
		/// <returns>
		/// A reference to the same <see cref="IFileFinderService"/> so that further filters or operations
		/// can be applied
		/// </returns>
		public IFileFinderService WithSearchOption(SearchOption searchOption)
		{
			_searchOption = searchOption;
			return this;
		}

		/// <summary>
		/// Finds all files that match the specified criteria
		/// </summary>
		/// <returns>An <see cref="IQueryable{FileInfo}"/> containing the search results</returns>
		public IQueryable<FileInfo> Find()
		{
			InitialiseAndValidateSearchCriteria();
			var files = GetFiles(_path, _extensions, _searchOption, _minimumSizeBytes, _maximumSizeBytes);

			return files.Take(_maximumSearchResults);
		}

		/// <summary>
		/// Finds the specified files
		/// </summary>
		/// <param name="orderByAction">A <see cref="Func{T, TResult}"/></param>
		/// <param name="isOrderByAscending"></param>
		/// <returns>An <see cref="IQueryable{FileInfo}"/> containing the search results</returns>
		public IQueryable<FileInfo> Find<TKey>(Func<FileInfo, TKey> orderByAction, bool isOrderByAscending)
		{
			InitialiseAndValidateSearchCriteria();
			var files = GetFiles(_path, _extensions, _searchOption, _minimumSizeBytes, _maximumSizeBytes);

			if (isOrderByAscending)
				files = files.OrderBy(f => orderByAction.Invoke(f));
			else
				files = files.OrderByDescending(f => orderByAction.Invoke(f));

			return files.Take(_maximumSearchResults);
		}

		/// <summary>
		/// A helper method to enumerate files based on multiple file extensions
		/// </summary>
		/// <param name="path">The path to search</param>
		/// <param name="extensions">A <see cref="List{string}"/> containing the file extensions to be searched</param>
		/// <param name="searchOption">The <see cref="SearchOption"/> that determines whether subdirectories are included</param>
		/// <param name="minimumSizeBytes">The minimum file size in bytes</param>
		/// <param name="maximumSizeBytes">The maximum file size in bytes</param>
		/// <returns>An <see cref="IQueryable{FileInfo}"/> containing the files with the specified extensions</returns>
		private IQueryable<FileInfo> GetFiles(
			string path,
			List<string> extensions,
			SearchOption searchOption,
			long minimumSizeBytes,
			long maximumSizeBytes)
		{
			return extensions.AsParallel()
				   .SelectMany(extension =>
						  new DirectoryInfo(path).EnumerateFiles(extension, searchOption))
				   .Where(f => f.Length >= minimumSizeBytes
						&& f.Length <= maximumSizeBytes)
				   .AsQueryable();
		}

		/// <summary>
		/// A helper method to initialise default values and validate arguments
		/// </summary>
		private void InitialiseAndValidateSearchCriteria()
		{
			if (!Directory.Exists(_path))
				throw new DirectoryNotFoundException("You must specify a directory to search");

			if (_minimumSizeBytes < 0)
				throw new ArgumentOutOfRangeException(null, "The minimum file size must be zero or more bytes");

			if (_maximumSizeBytes < 0)
				throw new ArgumentOutOfRangeException(null, "The maximum file size must be zero or more bytes");

			if (_extensions.Count == 0)
				_extensions.Add(".*");
		}
	}
}
