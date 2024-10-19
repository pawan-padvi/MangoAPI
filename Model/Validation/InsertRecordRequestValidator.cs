using FluentValidation;
using MangoAPI.Helper;
using System.ComponentModel.DataAnnotations.Schema;
namespace MangoAPI.Model.Validation
{
    [Table("user")]
    public class InsertRecordRequestValidator : AbstractValidator<InsertRecordRequest>
    {
        public InsertRecordRequestValidator()
        {
            RuleFor(model => model.FirstName)
            .NotEmpty().WithMessage(GlobalVariables.required_first_name)
            .MinimumLength(3).WithMessage(GlobalVariables.minimum_length_first_name)
            .MaximumLength(35).WithMessage(GlobalVariables.maximum_length_first_name);

            RuleFor(model => model.LastName)
            .NotEmpty().WithMessage(GlobalVariables.required_last_name)
            .MinimumLength(3).WithMessage(GlobalVariables.minimum_length_last_name)
            .MaximumLength(35).WithMessage(GlobalVariables.maximum_length_last_name);

            RuleFor(model => model.Age)
            .NotEmpty().WithMessage(GlobalVariables.required_age)
            .NotEqual(0).WithMessage(GlobalVariables.greaterthan_age)
            .GreaterThan(7).WithMessage(GlobalVariables.greaterthan_age)
            .LessThan(150).WithMessage(GlobalVariables.lessthan_age);

            RuleFor(model => model.Salary)
            .NotEmpty().WithMessage(GlobalVariables.required_salary)
            .LessThan(1000000).WithMessage(GlobalVariables.lessthan_salary);

            RuleFor(model => model.Contact)
             .NotEmpty().WithMessage(GlobalVariables.required_contact)
            .Matches(@"^\d{10}$").WithMessage(GlobalVariables.contact_must_be_10)
            .Must(IsValidContactNumber).WithMessage(GlobalVariables.invalid_contact_number);
        }
        private bool IsValidContactNumber(string contactNumber)
        {
            // Example: Avoid numbers like 0000000000 or 1234567890, etc.
            var invalidNumbers = new[] { "0000000000", "1234567890" };
            return !invalidNumbers.Contains(contactNumber);
        }
    }
}
