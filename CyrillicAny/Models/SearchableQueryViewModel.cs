using System.ComponentModel.DataAnnotations;

namespace CyrillicAny.Models
{
	public class SearchableQueryViewModel
	{
		[Required]
		public string SearchText { get; set; }
	}
}