using System.Threading.Tasks;
using CyrillicAny.Data.Service;
using CyrillicAny.Models;
using CyrillicAny.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyrillicAny.Api
{
	[Route("api/[controller]")]
	public class SearchController : Controller
	{
		private readonly ISearchQueriesService service;

		public SearchController(ISearchQueriesService service)
		{
			this.service = service;
		}

		[Authorize]
		[HttpPost]
		[Route("")]
		[ValidateModel]
		public async Task<IActionResult> PerformSearch(SearchableQueryViewModel model)
		{
			await this.service.SaveSearch(model.SearchText);
			return Ok();
		}
	}
}