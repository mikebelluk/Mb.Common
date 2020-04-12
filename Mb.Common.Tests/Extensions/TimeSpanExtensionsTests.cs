using System;
using Mb.Common.Extensions;
using Xunit;

namespace Mb.Common.Tests.Extensions
{
	public class TimeSpanExtensionsTests
	{
		[Fact()]
		public void Ticks_ReturnsCorrectValue()
		{
			var ts = 30.Ticks();
			Assert.Equal(30, ts.Ticks);
		}

		[Fact()]
		public void Milliseconds_ReturnsCorrectValue()
		{
			var ts = 30.Milliseconds();
			Assert.Equal(30 * TimeSpan.TicksPerMillisecond, ts.Ticks);
		}

		[Fact()]
		public void Seconds_ReturnsCorrectValue()
		{
			var ts = 30.Seconds();
			Assert.Equal(30 * TimeSpan.TicksPerSecond, ts.Ticks);
		}

		[Fact()]
		public void Minutes_ReturnsCorrectValue()
		{
			var ts = 30.Minutes();
			Assert.Equal(30 * TimeSpan.TicksPerMinute, ts.Ticks);
		}

		[Fact()]
		public void Hours_ReturnsCorrectValue()
		{
			var ts = 30.Hours();
			Assert.Equal(30 * TimeSpan.TicksPerHour, ts.Ticks);
		}

		[Fact()]
		public void Days_ReturnsCorrectValue()
		{
			var ts = 30.Days();
			Assert.Equal(30 * TimeSpan.TicksPerDay, ts.Ticks);
		}
	}
}
