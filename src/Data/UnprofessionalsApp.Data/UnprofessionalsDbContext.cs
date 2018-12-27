using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnprofessionalsApp.Data.Configurations;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Data
{
    public class UnprofessionalsDbContext : IdentityDbContext<UnprofessionalsAppUser, IdentityRole<int>, int>
    {
        public UnprofessionalsDbContext(DbContextOptions<UnprofessionalsDbContext> options)
            : base(options) { }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Firm> Firms { get; set; }

		public DbSet<Message> Messages { get; set; }

		public DbSet<Post> Posts { get; set; }

		public DbSet<Reply> Replies { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public DbSet<TagPost> TagsPosts { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
        {
			//There is no Configuration for User since I want Default Entities to list.
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
