using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnprofessionalsApp.Common
{
	public interface IRepository<TEntity>
		where TEntity : class
	{
		//Select заявка
		IQueryable<TEntity> All();

		void Add(TEntity entity);

		Task AddAsync(TEntity entity);

		Task AddRangeAsync(params TEntity[] entity);

		Task AddRangeAsync(IEnumerable<TEntity> entity);

		void Delete(TEntity entity);

		void SaveChanges();

		Task<int> SaveChangesAsync();
	}
}
