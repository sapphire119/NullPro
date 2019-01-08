using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnprofessionalsApp.DataServices.Contracts;

namespace UnprofessionalsApp.DataServices
{
	public class FilesService : IFilesService
	{
		public XDocument ParseToXDocument(string readFile)
		{
			return XDocument.Parse(readFile);
		}

		public string ReadAllTextFromFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				return default(string);
			}

			var readFile = File.ReadAllText(filePath);

			return readFile;
		}

		public async Task<string> ReadFile(IFormFile formFile)
		{
			//TODO: try and test this
			long size = formFile.Length;

			// full path to file in temp location
			var filePath = Path.GetTempFileName();

			if (formFile.Length > 0)
			{
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await formFile.CopyToAsync(stream);
				}
			}

			var result = filePath;

			return result;
		}
	}
}
