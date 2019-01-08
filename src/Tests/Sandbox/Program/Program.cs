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
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataServices;
//using UnprofessionalsApp.Mapping;
using Microsoft.AspNetCore.Identity;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

//using AngleSharp;
//using AngleSharp.Parser.Html;
//using Microsoft.EntityFrameworkCore;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Sandbox
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			//Console.OutputEncoding = Encoding.UTF8;
			//Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");

			//var dateTime = DateTime.UtcNow;

			//var format = dateTime.ToString(@"d MMMM, yyyy", CultureInfo.InvariantCulture);

			//var encode = WebUtility.UrlEncode(@"https://vignette.wikia.nocookie.net/paragonthegame/images/9/9b/Paragon-logo-full.png/revision/latest?cb=20160901131732");

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
			var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false, true)
				.AddEnvironmentVariables()
				.Build();

			//IConfiguration
			var test = configuration.GetSection("Cloudinary").GetChildren().ToDictionary(x => x.Key, k => k.Value);

			var account = new Account(test["cloud_name"], test["cloud_key"], test["cloud_secret"]);

			Cloudinary cloudinary = new Cloudinary(account);
			var imageUploadParams = new ImageUploadParams()
			{
				File = new FileDescription(@"https://antitrustlair.files.wordpress.com/2013/02/post_danmark.jpg")
			};

			var imageUploadParams1 = new ImageUploadParams()
			{
				File = new FileDescription(@"https://wallpaperbrowse.com/media/images/soap-bubble-1958650_960_720.jpg")
			};

			var imageUploadParams2 = new ImageUploadParams()
			{
				File = new FileDescription(@"https://www.w3schools.com/w3css/img_lights.jpg")
			};

			var imageUploadParams3 = new ImageUploadParams()
			{
				File = new FileDescription(@"https://antitrustlair.files.wordpress.com/2013/02/post_danmark.jpg")
			};

			var imageUploadParams4 = new ImageUploadParams()
			{
				File = new FileDescription(@"https://upload.wikimedia.org/wikipedia/commons/thumb/6/6c/No_image_3x4.svg/1024px-No_image_3x4.svg.png")
			};

			var imageUploadParams5 = new ImageUploadParams()
			{
				File = new FileDescription(@"https://wallpaperbrowse.com/media/images/soap-bubble-1958650_960_720.jpg")
			};



			var uploadResult = cloudinary.Upload(imageUploadParams);
			var uploadResult1 = cloudinary.Upload(imageUploadParams1);
			var uploadResult2 = cloudinary.Upload(imageUploadParams2);
			var uploadResult3 = cloudinary.Upload(imageUploadParams3);
			var uploadResult4 = cloudinary.Upload(imageUploadParams4);
			var defaultResult = cloudinary.Upload(imageUploadParams5);


			var uploadUrl = uploadResult.SecureUri.ToString();
			//			var user = new UnprofessionalsAppUser();

			//			var test = user.Comments
			//			.OrderByDescending(p => p.DateOfCreation)
			//			.AsEnumerable();
			//			//using (var context = new UnprofessionalsDbContext(null))
			//			//{
			//			//	var userRepo = new DbRepository<UnprofessionalsAppUser>(context);

			//			//	var regularPosts = userRepo.All().Where(u => u.Id == 1)
			//			//			.SelectMany(u => u.Comments);

			//			//}


			//			//var post = new Post();
			//			//var user = new UnprofessionalsAppUser();
			//			//IEnumerable<Post> posts = user.Posts.Where(p => p.FirmId != null);
			//			//IEnumerable<Tag> tags = post.Tags.Select(t => t.Tag.Name);

			//			//var lower = pageNumber % 10;

			//			//var higher = pageNumber % 10;
			//			//var higherPage = Math.Ceiling(higher);

			//			//var lower1 = pageNumber1 % 10;
			//			//var lowerPage1 = Math.Floor(lower1);
			//			//var higher1 = pageNumber1 % 10;
			//			//var higherPage1 = Math.Ceiling(higher1);

			//			//Console.WriteLine("Please Enter the Location of the file");
			//			//// get the location we want to get the sitemaps from 
			//			//string dirLoc = @"D:\Downloads\tr030312062018\2018\3";
			//			//// get all teh sitemaps 
			//			//string[] sitemaps = Directory.GetFiles(dirLoc);
			//			//StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\locs.txt", true);

			//			//// loop through each file 
			//			//foreach (string sitemap in sitemaps)
			//			//{
			//			//	try
			//			//	{
			//			//		var xmlString = File.ReadAllText(sitemap);


			//			//		// new xdoc instance 
			//			//		XDocument xDoc = XDocument.Parse(xmlString);

			//			//		var root = xDoc.Root.Elements();

			//			//		foreach (var xElement in root)
			//			//		{
			//			//			var elements = xElement.Elements().ToArray();
			//			//			if (xElement.Name.LocalName == "Body")
			//			//			{
			//			//				var deedsAll = elements.Elements().ToArray();

			//			//				foreach (var deed in deedsAll)
			//			//				{
			//			//					var firmId = deed.Attribute("GUID")?.Value ?? string.Empty;

			//			//					var bulstat = deed.Attribute("UIC")?.Value ?? string.Empty;

			//			//					var companyName = deed.Attribute("CompanyName")?.Value ?? string.Empty;

			//			//					var legalForm = deed.Attribute("LegalForm")?.Value ?? string.Empty;

			//			//					if (string.IsNullOrWhiteSpace(firmId) ||
			//			//						string.IsNullOrWhiteSpace(bulstat) ||
			//			//						string.IsNullOrWhiteSpace(companyName) ||
			//			//						string.IsNullOrWhiteSpace(legalForm) )
			//			//					{
			//			//						throw new Exception($"Coudn't save data for firm: \n {deed?.Value ?? string.Empty}");
			//			//					}


			//			//				}
			//			//			}
			//			//		}
			//			//	}
			//			//	catch { }
			//			//}
			//			//Console.WriteLine("All Done :-)");
			//			//Console.ReadKey();
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
			services.AddTransient<IUsersService, UserService>();
		}
	}
}