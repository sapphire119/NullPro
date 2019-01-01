using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Data
{
	public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
		where TEntity : class
	{
		private readonly UnprofessionalsDbContext context;
		private DbSet<TEntity> dbset;

		public DbRepository(UnprofessionalsDbContext context)
		{
			this.context = context;
			this.dbset = this.context.Set<TEntity>();
		}

		public void Add(TEntity entity)
		{
			this.dbset.Add(entity);
		}

		public Task AddAsync(TEntity entity)
		{
			return this.dbset.AddAsync(entity);
		}

		public IQueryable<TEntity> All()
		{
			return this.dbset;
		}

		public void Delete(TEntity entity)
		{
			this.dbset.Remove(entity);
		}

		public void SaveChanges()
		{
			this.context.SaveChanges();
		}

		public Task<int> SaveChangesAync()
		{
			return this.context.SaveChangesAsync();
		}

		public void Dispose()
		{
			this.context.Dispose();
		}
	}
}
