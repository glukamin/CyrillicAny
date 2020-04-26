using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyrillicAny.Data.Models;
using CyrillicAny.Data.Repositories;
using CyrillicAny.Entity.SearchedQueries;

namespace CyrillicAny.Data.Service
{
	public class SearchQueriesService : ISearchQueriesService
	{
		private readonly ISearchedQueriesRepository repository;

		public SearchQueriesService(ISearchedQueriesRepository repository)
		{
			this.repository = repository;
		}

		public async Task SaveSearch(string query)
		{
			await this.repository.Add(new SearchedQuery() { Query = query });
		}

		public async Task<IEnumerable<QueryDTO>> GetResults(string query)
		{
			List<SearchedQuery> queries = await this.repository.FilterBy(x => x.Query == query);
			return queries.Select(x => new QueryDTO(x.Query));
		}
	}
}
