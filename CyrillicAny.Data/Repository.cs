using System.Threading.Tasks;
using CyrillicAny.Entity;

namespace CyrillicAny.Data
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly ApiContext Context;

		public Repository(ApiContext context)
		{
			this.Context = context;
		}

		public async Task<TEntity> Add(TEntity entity)
		{
			this.Context.Set<TEntity>()
				.Add(entity);
			await this.Context.SaveChangesAsync();
			return entity;
		}
	}
}