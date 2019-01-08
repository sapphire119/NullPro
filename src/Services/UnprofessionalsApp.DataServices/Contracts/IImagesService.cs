using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IImagesService
	{
		Task<Image> CreateImage(string imageUrl);

		Task<string> GetUrlPath(string filePath);

		Task<string> ReadFile(IFormFile file);
	}
}
