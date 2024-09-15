using FluentValidation.Results;

namespace InkWell.MAUI.Common.Extensions;

public static class ValidationExtensions
{
	public static string GetError(this ValidationResult result, string property)
	{
		return result.Errors.FirstOrDefault(x => x.PropertyName == property + ".Value")?.ErrorMessage;
	}
}