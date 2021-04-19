using System;
using System.IO;
using System.Linq;
using System.Net;
using Mb.Common.Contracts.Services.Net;

namespace Mb.Common.Services.Net
{
	/// <summary>
	/// Provides additional services for when working with URLs
	/// </summary>
	public class UrlService : IUrlService
	{
		#region Properties

		/// <summary>
		/// The maximum number of redirections to allow when resolving a URL
		/// </summary>
		public int MaximumRedirections { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="maximumRedirections">
		/// Limits the maximum number of redirections allowed; defaults to <c>10</c>.
		/// </param>
		public UrlService(int maximumRedirections = 10)
		{
			MaximumRedirections = maximumRedirections;
		}

		#endregion

		#region Get Filename from URL

		/// <summary>
		/// Attempts to determine a filename for a given URL
		/// </summary>
		/// <param name="url">The URL to check</param>
		/// <param name="filename">When this method returns, it contains the filename which was derived from the URL or <c>null</c> on failure</param>
		/// <returns><c>true</c> if the filename could be determined; otherwise <c>false</c></returns>
		public bool TryGetFilename(string url, out string filename)
		{
			if (TryGetFilenameFromPath(url, out filename))
			{
				filename = TrimFilename(filename);
				return true;
			}

			var request = (HttpWebRequest)WebRequest.Create(url);
			request.AllowAutoRedirect = true;
			request.MaximumAutomaticRedirections = MaximumRedirections;

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				return TryGetFilenameFromPath(response.ResponseUri.AbsoluteUri, out filename)
					|| TryGetFilenameFromPath(response.ResponseUri.AbsolutePath, out filename)
					|| TryGetFilenameFromHeaders(response, out filename);
			}
		}

		/// <summary>
		/// Attempts to get the filename from the URL's path
		/// </summary>
		/// <param name="url">The URL to check</param>
		/// <param name="filename">When this method returns, it contains the filename which was derived from the URL or <c>null</c> on failure</param>
		/// <returns><c>true</c> if the filename could be determined; otherwise <c>false</c></returns>
		private bool TryGetFilenameFromPath(string url, out string filename)
		{
			filename = null;

			var index = url.LastIndexOf("/");
			if (index == -1)
				return false;

			filename = TrimFilename(url.Substring(index + 1));

			var isValid = !string.IsNullOrEmpty(filename)
			  && filename.IndexOfAny(Path.GetInvalidFileNameChars()) == -1
			  && !string.IsNullOrEmpty(Path.GetExtension(filename));

			return isValid;
		}

		/// <summary>
		/// Attempts to get the filename using the response header
		/// </summary>
		/// <param name="response">The <see cref="HttpWebResponse"/> to be used when attempting to extract the filename</param>
		/// <param name="filename">When this method returns, it contains the filename which was derived from the URL or <c>null</c> on failure</param>
		/// <returns><c>true</c> if the filename could be determined; otherwise <c>false</c></returns>
		private bool TryGetFilenameFromHeaders(HttpWebResponse response, out string filename)
		{
			filename = null;

			if (response.Headers
					.AllKeys
					.Any(k => k.Equals("Content-Disposition", StringComparison.InvariantCultureIgnoreCase)))
			{
				var value = response.Headers["Content-Disposition"];
				const string fieldName = "filename=";
				var index = value.IndexOf(fieldName, StringComparison.InvariantCultureIgnoreCase);
				if (index != -1)
				{
					filename = TrimFilename(value.Substring(index + fieldName.Length));
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Trims unwanted characters from the specified filename
		/// </summary>
		/// <param name="filename">The filename to trim</param>
		/// <returns>The trimmed filename</returns>
		private string TrimFilename(string filename)
		{
			if (string.IsNullOrEmpty(filename))
				return filename;

			return filename
				.Trim()
				.Trim(new char[] { '\'', '"' });
		}

		#endregion
	}
}
