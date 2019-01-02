using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.Data;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Web.Extensions
{
	public static class DbInitializer
	{
		public static void Initialize(UnprofessionalsDbContext context, IServiceProvider services)
		{
			SeedFirms(context);
			//SeedPosts(context);
			//SeedCategories(context);
			//SeedUsers(context);
			//SeedComments(context);
			SeedRolesWithPowerUser(services).GetAwaiter().GetResult();
		}

		private static void SeedFirms(UnprofessionalsDbContext context)
		{
			if (context.Firms.Any())
			{
				return;
			}

			// get the location we want to get the sitemaps from 
			string dirLoc = @"D:\TR\";

			var isDbSeeded = false;
			// get all teh sitemaps 
			List<string> sitemaps = GetFileList("*", dirLoc).ToList();

			if (!sitemaps.All(map => map.EndsWith(".xml")))
			{
				var unsupportedFiles = sitemaps.Where(map => !map.EndsWith(".xml")).ToArray();

				throw new Exception($"Folder contains files in unsupported format: " +
					$"{string.Join(Environment.NewLine, unsupportedFiles)}");
			}


			var currentFirms = new List<Firm>();

			// loop through each file 
			foreach (string sitemap in sitemaps)
			{
				if (isDbSeeded)
				{
					break;
				}

				var xmlString = File.ReadAllText(sitemap);


				// new xdoc instance 
				XDocument xDoc = XDocument.Parse(xmlString);

				var root = xDoc.Root.Elements();

				foreach (var xElement in root)
				{
					var elements = xElement.Elements().ToArray();
					if (xElement.Name.LocalName == "Body")
					{
						var deedsAll = elements.Elements().ToArray();

						foreach (var deed in deedsAll)
						{
							var firmId = deed.Attribute("GUID")?.Value ?? string.Empty;

							var bulstat = deed.Attribute("UIC")?.Value ?? string.Empty;

							var companyName = deed.Attribute("CompanyName")?.Value ?? string.Empty;

							var legalForm = deed.Attribute("LegalForm")?.Value ?? string.Empty;

							if (string.IsNullOrWhiteSpace(firmId) ||
								string.IsNullOrWhiteSpace(bulstat) ||
								string.IsNullOrWhiteSpace(companyName) ||
								string.IsNullOrWhiteSpace(legalForm))
							{
								throw new Exception($"Coudn't save data for firm: \n {deed?.Value ?? string.Empty}");
							}

							var isValidGuid = Guid.TryParse(firmId, out var firmGuidId);
							if (!isValidGuid)
							{
								throw new Exception("Coudn't parse guid id");
							}

							var currentFirm = new Firm
							{
								Id = firmGuidId,
								Name = companyName,
								UniqueFirmId = bulstat,
								LegalForm = legalForm
							};

							if (currentFirms.Any(f =>
									f.Id == currentFirm.Id || f.UniqueFirmId == currentFirm.UniqueFirmId))
							{
								continue;
							}

							currentFirms.Add(currentFirm);
						}

						if (currentFirms.Count > 1200)
						{
							isDbSeeded = true;
							break;
						}
					}

				}
			}

			context.AddRange(currentFirms);

			context.SaveChanges();
		}

		private static async Task SeedRolesWithPowerUser(IServiceProvider services)
		{
			await CreateUserRoles(services);
		}

		private static async Task CreateUserRoles(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<UnprofessionalsAppUser>>();
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

			if (roleManager.Roles.Any())
			{
				return;
			}

			IdentityResult roleResult;

			foreach (var roleName in ProjectConstants.ApprovedRoles)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					//create the roles and seed them to the database: Question 1
					roleResult = await roleManager.CreateAsync(new IdentityRole<int>(roleName));
				}
			}

			//Here you could create a super user who will maintain the web app
			var poweruser = new UnprofessionalsAppUser
			{
				UserName = /*Configuration["AppSettings:UserName"]*/"admin",
				Email = /*Configuration["AppSettings:UserEmail"]*/"admin@admin.admin",
			};
			//Ensure you have these values in your appsettings.json file
			string userPWD = /*Configuration["AppSettings:UserPassword"]*/ "asd123";
			var _user = await userManager.FindByNameAsync("admin");

			if (_user == null)
			{
				var createPowerUser = await userManager.CreateAsync(poweruser, userPWD);
				if (createPowerUser.Succeeded)
				{
					//here we tie the new user to the role
					await userManager.AddToRoleAsync(poweruser, ProjectConstants.AdminRole);
				}
			}
		}

		private static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
		{
			Queue<string> pending = new Queue<string>();
			pending.Enqueue(rootFolderPath);
			string[] tmp;
			while (pending.Count > 0)
			{
				rootFolderPath = pending.Dequeue();
				try
				{
					tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				for (int i = 0; i < tmp.Length; i++)
				{
					yield return tmp[i];
				}
				tmp = Directory.GetDirectories(rootFolderPath);
				for (int i = 0; i < tmp.Length; i++)
				{
					pending.Enqueue(tmp[i]);
				}
			}
		}
	}
}
