using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnprofessionalsApp.Web.Extensions
{
	public static class CloudinaryInitializer
	{
		public static Account Initialize(IConfiguration configuration)
		{
			var dataForCloud = configuration.GetSection("Cloudinary").GetChildren().ToDictionary(x => x.Key, k => k.Value);

			var account = new Account(dataForCloud["cloud_name"], dataForCloud["cloud_key"], dataForCloud["cloud_secret"]);

			return account;
		}
	}
}
