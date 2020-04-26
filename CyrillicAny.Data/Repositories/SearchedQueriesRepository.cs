using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CyrillicAny.Data.Models;
using CyrillicAny.Entity.SearchedQueries;
using Microsoft.EntityFrameworkCore;

namespace CyrillicAny.Data.Repositories
{
	public class SearchedQueriesRepository : Repository<SearchedQuery>, ISearchedQueriesRepository
	{
		public SearchedQueriesRepository(ApiContext context) : base(context)
		{
		}

		public Task<List<SearchedQuery>> FilterBy(Expression<Func<SearchedQuery, bool>> filter)
		{
			IQueryable<SearchedQuery> searchedQueries = Context.Set<SearchedQuery>().Where(filter);
			return searchedQueries.ToListAsync();
		}
	}
}