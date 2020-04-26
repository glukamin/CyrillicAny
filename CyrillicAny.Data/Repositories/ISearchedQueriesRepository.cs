using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CyrillicAny.Entity.SearchedQueries;

namespace CyrillicAny.Data.Repositories
{
	public interface ISearchedQueriesRepository : IRepository<SearchedQuery>
	{
		Task<List<SearchedQuery>> FilterBy(Expression<Func<SearchedQuery, bool>> filter);
	}
}