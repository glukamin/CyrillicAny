using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CyrillicAny.Validation
{
	public class ValidationResultModel
	{
		public ValidationResultModel(ModelStateDictionary modelState)
		{
			this.Message = "Validation Failed";
			this.Errors = modelState.Keys
									.SelectMany(key => modelState[key]
														.Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
									.ToList();
		}

		public List<ValidationError> Errors { get; }

		public string Message { get; }
	}
}