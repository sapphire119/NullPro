using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnprofessionalsApp.CustomAttributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class CustomFileExtensionAttribute : ValidationAttribute
	{
		private List<string> AllowedExtensions { get; set; }

		public CustomFileExtensionAttribute(string fileExtensions)
		{
			this.AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(v => v.Trim())
				.ToList();
		}

		public override bool IsValid(object value)
		{
			IFormFile formFile = value as IFormFile;

			if (formFile != null)
			{
				var fileName = formFile.FileName;

				var result = this.AllowedExtensions.Any(e => fileName.EndsWith(e));
				return result;
			}

			return true;
		}
	}
}
