using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Data.Configurations
{
	public class ImageConfig : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Url).IsRequired();
		}
	}
}
