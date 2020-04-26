using System.Threading.Tasks;

namespace CyrillicAny.Data.Service
{
	public interface ISearchQueriesService
	{
		Task SaveSearch(string queryQuery);
	}
}