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

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using UnprofessionalsApp.Models;

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

			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

			using (var serviceScope = serviceProvider.CreateScope())
			{
				serviceProvider = serviceScope.ServiceProvider;
				SandboxCode(serviceProvider);
			}
		}

		private static void SandboxCode(IServiceProvider serviceProvider)
		{
			var post = new Post();
			//IEnumerable<Tag> tags = post.Tags.Select(t => t.Tag.Name);

			//var lower = pageNumber % 10;

			//var higher = pageNumber % 10;
			//var higherPage = Math.Ceiling(higher);

			//var lower1 = pageNumber1 % 10;
			//var lowerPage1 = Math.Floor(lower1);
			//var higher1 = pageNumber1 % 10;
			//var higherPage1 = Math.Ceiling(higher1);

			//Console.WriteLine("Please Enter the Location of the file");
			//// get the location we want to get the sitemaps from 
			//string dirLoc = @"D:\Downloads\tr030312062018\2018\3";
			//// get all teh sitemaps 
			//string[] sitemaps = Directory.GetFiles(dirLoc);
			//StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\locs.txt", true);

			//// loop through each file 
			//foreach (string sitemap in sitemaps)
			//{
			//	try
			//	{
			//		var xmlString = File.ReadAllText(sitemap);


			//		// new xdoc instance 
			//		XDocument xDoc = XDocument.Parse(xmlString);

			//		var root = xDoc.Root.Elements();

			//		foreach (var xElement in root)
			//		{
			//			var elements = xElement.Elements().ToArray();
			//			if (xElement.Name.LocalName == "Body")
			//			{
			//				var deedsAll = elements.Elements().ToArray();

			//				foreach (var deed in deedsAll)
			//				{
			//					var firmId = deed.Attribute("GUID")?.Value ?? string.Empty;

			//					var bulstat = deed.Attribute("UIC")?.Value ?? string.Empty;

			//					var companyName = deed.Attribute("CompanyName")?.Value ?? string.Empty;

			//					var legalForm = deed.Attribute("LegalForm")?.Value ?? string.Empty;

			//					if (string.IsNullOrWhiteSpace(firmId) ||
			//						string.IsNullOrWhiteSpace(bulstat) ||
			//						string.IsNullOrWhiteSpace(companyName) ||
			//						string.IsNullOrWhiteSpace(legalForm) )
			//					{
			//						throw new Exception($"Coudn't save data for firm: \n {deed?.Value ?? string.Empty}");
			//					}


			//				}
			//			}
			//		}
			//	}
			//	catch { }
			//}
			//Console.WriteLine("All Done :-)");
			//Console.ReadKey();
		}

		private static void ConfigureServices(ServiceCollection services)
		{
			var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false, true)
				.AddEnvironmentVariables()
				.Build();

			services.AddDbContext<UnprofessionalsDbContext>(options =>
			{
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
		}
	}
}