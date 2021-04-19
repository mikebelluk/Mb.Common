using Mb.Common.Contracts;
using Mb.Common.Contracts.Services.Dates;
using Mb.Common.Contracts.Services.HumanReadable;
using Mb.Common.Contracts.Services.IO;
using Mb.Common.Contracts.Services.Net;
using Mb.Common.Services;
using Mb.Common.Services.Dates;
using Mb.Common.Services.HumanReadable;
using Mb.Common.Services.IO;
using Mb.Common.Services.Net;
using Microsoft.Extensions.DependencyInjection;

namespace Mb.Common
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddMbCommon(this IServiceCollection services)
		{
			services.AddTransient<IDateService, DateService>();
			services.AddTransient<IBytesToHumanReadableService, BytesToHumanReadableService>();
			services.AddTransient<IHumanReadableDateTimeService, HumanReadableDateTimeService>();
			services.AddTransient<IHumanReadableService, HumanReadableService>();
			services.AddTransient<IFileSystemService, FileSystemService>();
			services.AddTransient<IUrlService, UrlService>();
			services.AddTransient<IEnumService, EnumService>();
			services.AddTransient<IByteSizeService, ByteSizeService>();
			services.AddTransient<IFileFinderService, FileFinderService>();

			return services;
		}
	}
}
