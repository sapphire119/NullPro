using System.Linq;
using System.Threading.Tasks;

namespace UnprofessionalsApp.Common
{
	public interface IRepository<TEntity>
		where TEntity : class
	{
		//Select заявка
		IQueryable<TEntity> All();

		Task AddAsync(TEntity entity);

		void Delete(TEntity entity);

		Task<int> SaveChangesAync();
	}
}
