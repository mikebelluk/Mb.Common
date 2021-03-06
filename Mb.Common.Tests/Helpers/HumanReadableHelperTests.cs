﻿using Mb.Common.Contracts.Services.HumanReadable;
using Mb.Common.Services.HumanReadable;
using Xunit;

namespace Mb.Common.Tests.Helpers
{
	public class HumanReadableHelperTests
	{
		#region Static Fields

		private static readonly IHumanReadableService _humanReadable = new HumanReadableService();

		#endregion

		[Theory()]
		[InlineData(512, "512 bytes")]
		[InlineData(1024, "1 KB")]
		[InlineData(1024 + 512, "1.5 KB")]
		[InlineData(1024 * 1024 / 2, "512 KB")]
		[InlineData(1024 * 1024, "1 MB")]
		[InlineData(1024 * 1024 * 1.5, "1.5 MB")]
		[InlineData(1024 * 1024 * 1024, "1 GB")]
		[InlineData(1024 * 1024 * 1024 * 1.5, "1.5 GB")]
		[InlineData(1024L * 1024 * 1024 * 1024, "1 TB")]
		[InlineData(1024L * 1024 * 1024 * 1024 * 1.5, "1.5 TB")]
		[InlineData(1024L * 1024 * 1024 * 1024 * 1024, "1 PB")]
		[InlineData(1024L * 1024 * 1024 * 1024 * 1024 * 1.5, "1.5 PB")]
		[InlineData(1024L * 1024 * 1024 * 1024 * 1024 * 1024, "1 EB")]
		[InlineData(1024L * 1024 * 1024 * 1024 * 1024 * 1024 * 1.5, "1.5 EB")]
		public void BytesToHumanReadableSize_TheoryReturnsCorrectValue(long fileSizeBytes, string expected)
		{
			var actual = _humanReadable.Bytes.AsReadable(fileSizeBytes);
			Assert.Equal(expected, actual);
		}
	}
}
