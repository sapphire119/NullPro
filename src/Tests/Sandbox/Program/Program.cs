using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnprofessionalsApp.Data;
using UnprofessionalsApp.Common;
using System.Globalization;

//using AngleSharp;
//using AngleSharp.Parser.Html;
//using Microsoft.EntityFrameworkCore;

namespace Sandbox
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");

			var dateTime = DateTime.UtcNow;

			var format = dateTime.ToString(@"d MMMM, yyyy", CultureInfo.InvariantCulture);

			var encode = WebUtility.UrlEncode(@"https://vignette.wikia.nocookie.net/paragonthegame/images/9/9b/Paragon-logo-full.png/revision/latest?cb=20160901131732");

			////var serviceCollection = new ServiceCollection();
			////ConfigureServices(serviceCollection);
			////IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

			//using (var serviceScope = serviceProvider.CreateScope())
			//{
			//	serviceProvider = serviceScope.ServiceProvider;
			//	SandboxCode(serviceProvider);
			//}
		}

		//private static void SandboxCode(IServiceProvider serviceProvider)
		//{
			
		//}

		//private static void ConfigureServices(ServiceCollection services)
		//{
		//	var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
		//		.AddJsonFile("appsettings.json", false, true)
		//		.AddEnvironmentVariables()
		//		.Build();

		//	services.AddDbContext<UnprofessionalsDbContext>(options =>
		//		options.UseSqlServer(
		//			configuration.GetConnectionString("DefaultConnection")));

		//	services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
		//}
	}
}