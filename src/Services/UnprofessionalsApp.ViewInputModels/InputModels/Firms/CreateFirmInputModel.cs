using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UnprofessionalsApp.CustomAttributes;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Firms
{
	public class CreateFirmInputModel
	{
		[Required]
		[CustomFileExtension(".xml", ErrorMessage = "Accepted file formats are: {0}")]
		public IFormFile FirmFile { get; set; }
	}
}
