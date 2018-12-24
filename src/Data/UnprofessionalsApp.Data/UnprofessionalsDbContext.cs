﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Data
{
    public class UnprofessionalsDbContext : IdentityDbContext<UnprofessionalsAppUser, IdentityRole<int>, int>
    {
        public UnprofessionalsDbContext(DbContextOptions<UnprofessionalsDbContext> options)
            : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
        {
			base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
