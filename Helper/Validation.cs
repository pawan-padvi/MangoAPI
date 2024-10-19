using FluentValidation;
namespace MangoAPI.Helper
{
    public static class Validation
    {
        public static Dictionary<string, string>? ValidateModel<T>(T model, IValidator<T> validator)
        {
            var results = validator.Validate(model);

            if(results.IsValid)
            {
                return null;
            }
            var errors = results.Errors.Distinct().ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage);
            return errors;
        }
    }
}
