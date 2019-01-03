namespace UnprofessionalsApp.Web
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.UI;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.HttpsPolicy;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using UnprofessionalsApp.Data;
	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.Web.Extensions;

	using AutoMapper;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;
	using UnprofessionalsApp.Mapping;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.DataServices;

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			AutoMapperConfig.RegisterMappings(typeof(PostViewModel));

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<UnprofessionalsDbContext>(options =>
								options.UseSqlServer(
									this.Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<UnprofessionalsAppUser>(options =>
			{
				options.Password.RequiredLength = 6;

				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;

				options.User.RequireUniqueEmail = true;
			})
			.AddRoles<IdentityRole<int>>()
			.AddEntityFrameworkStores<UnprofessionalsDbContext>();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Identity/Account/Login";
				options.Cookie.HttpOnly = true;
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			//App Services
			services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

			services.AddTransient<IPostsService, PostsService>();
			services.AddTransient<IFirmsService, FirmsService>();
			services.AddTransient<IHomeService, HomeService>();
			services.AddTransient<ICategoriesService, CategoriesService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<UnprofessionalsAppUser> userManager, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
				routes.MapRoute(
					name: "areas",
					template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
			});

		}
	}
}
