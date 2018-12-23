namespace UnprofessionalsApp.Data
{
	using System.IO;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Design;
	using Microsoft.EntityFrameworkCore.Diagnostics;
	using Microsoft.Extensions.Configuration;

	public class UnprofessionalsDbContextFactory : IDesignTimeDbContextFactory<UnprofessionalsDbContext>
	{
		public UnprofessionalsDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			var builder = new DbContextOptionsBuilder<UnprofessionalsDbContext>();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			builder.UseSqlServer(connectionString)
				.UseLazyLoadingProxies();

			//Stop Client Querry evaluation
			builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

			return new UnprofessionalsDbContext(builder.Options);
		}
	}
}
