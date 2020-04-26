namespace CyrillicAny.Data.Models
{
	public class QueryDTO
	{
		public QueryDTO(string query)
		{
			this.Result = query;
		}

		public string Result { get; }
	}
}