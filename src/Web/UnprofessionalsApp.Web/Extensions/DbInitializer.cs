using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using UnprofessionalsApp.Common;
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

				var currentFirms = new List<Firm>();

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
									f.Id == currentFirm.Id || f.UniqueFirmId == currentFirm.UniqueFirmId) ||
								context.Firms.Any(f => 
									f.Id == currentFirm.Id || f.UniqueFirmId == currentFirm.UniqueFirmId))
							{
								continue;
							}

							currentFirms.Add(currentFirm);
						}

						context.Firms.AddRange(currentFirms);

						context.SaveChanges();

						if (context.Firms.Count() > 1200)
						{
							isDbSeeded = true;
							break;
						}
					}

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
