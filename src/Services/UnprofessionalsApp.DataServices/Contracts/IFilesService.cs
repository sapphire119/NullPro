using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IFilesService
	{
		Task<string> ReadFile(IFormFile file);

		string ReadAllTextFromFile(string filePath);

		XDocument ParseToXDocument(string readFile);
	}
}
