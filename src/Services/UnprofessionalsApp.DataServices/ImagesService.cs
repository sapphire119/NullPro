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

		public string GetUrlPath(ImageUploadResult uploadResult)
		{
			var urlPath = uploadResult.SecureUri.ToString();

			return urlPath;
		}

		public async Task<ImageUploadResult> UploadImageFromFilePath(string filePath)
		{
			var uploadParams = new ImageUploadParams
			{
				File = new FileDescription(string.Format(@"{0}", filePath))
			};

			var uploadResult = await this.cloudinary.UploadAsync(uploadParams);

			return uploadResult;
		}
	}
}
