using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using UnprofessionalsApp.Data;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Web.Extensions
{
	public static class DbInitializer
	{
		public static void Initialize(UnprofessionalsDbContext context)
		{
			if (context.Firms.Any())
			{
				return;
			}

			Console.WriteLine("Please Enter the Location of the file");
			// get the location we want to get the sitemaps from 
			string dirLoc = @"D:\Downloads\tr030312062018\2018\3";
			// get all teh sitemaps 
			string[] sitemaps = Directory.GetFiles(dirLoc);

			// loop through each file 
			foreach (string sitemap in sitemaps)
			{
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

							if (context.Firms.Any(f => f.UniqueFirmId == currentFirm.UniqueFirmId))
							{
								continue;
							}

							context.Firms.Add(currentFirm);
						}


					}
				}
			}
		}
	}
}
