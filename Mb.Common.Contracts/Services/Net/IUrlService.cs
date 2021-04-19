namespace Mb.Common.Contracts.Services.Net
{
	public interface IUrlService
	{
		/// <summary>
		/// Attempts to determine a filename for a given URL
		/// </summary>
		/// <param name="url">The URL to check</param>
		/// <param name="filename">When this method returns, it contains the filename which was derived from the URL or <c>null</c> on failure</param>
		/// <returns><c>true</c> if the filename could be determined; otherwise <c>false</c></returns>
		bool TryGetFilename(string url, out string filename);
	}
}
