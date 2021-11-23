using CrudDemo.App.Dtos;
using FluentValidation;

namespace CrudDemo.App.Employee.Commands.Validation
{
    public class CreateEmployeeCommandValidator : AbstractValidator<EmployeeCreateDto>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .Must(x => x.Length > 1)
                .WithMessage("First name must be at least 1 character")
                .Must(x => x.Length <= 30)
                .WithMessage("First name is too long. Max is 30 characters.");

            RuleFor(x => x.LastName)
                .Must(x => x.Length > 1)
                .WithMessage("Last name must be at least 1 character")
                .Must(x => x.Length <= 30)
                .WithMessage("Last name is too long. Max is 30 characters."); ;

            RuleFor(x => x.Email)
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage(x => $"{ x.Email} is not a valid email address.");

            RuleFor(x => x.DepartmentCode)
                .NotEmpty()
                .WithMessage("Department code is required.");
        }
    }
}
