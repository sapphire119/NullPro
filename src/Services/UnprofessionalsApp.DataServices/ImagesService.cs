using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataServices
{
	public class ImagesService : IImagesService
	{
		private readonly Cloudinary cloudinary;
		private readonly IMapper mapper;
		private readonly IRepository<Image> imageRepository;

		public ImagesService(Cloudinary cloudinary, IMapper mapper, IRepository<Image> imageRepository)
		{
			this.cloudinary = cloudinary;
			this.mapper = mapper;
			this.imageRepository = imageRepository;
		}

		public async Task<Image> CreateImage(string imageUrl)
		{
			var destination = this.mapper.Map<Image>(WebUtility.UrlEncode(imageUrl));

			await this.imageRepository.AddAsync(destination);

			var statusCode = await this.imageRepository.SaveChangesAsync();

			if (statusCode != GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return null;
			}

			return destination;
		}

		public async Task<string> GetUrlPath(string filePath)
		{
			//TODO: try and test this
			var uploadParams = new ImageUploadParams
			{
				File = new FileDescription(string.Format(@"{0}", filePath))
			};

			var uploadResult = await this.cloudinary.UploadAsync(uploadParams);

			var urlPath = uploadResult.SecureUri.ToString();

			return urlPath;
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
