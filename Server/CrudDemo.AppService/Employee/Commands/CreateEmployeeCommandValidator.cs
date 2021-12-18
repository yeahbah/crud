using FluentValidation;

namespace CrudDemo.App.Employee.Commands;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeCreateDto.FirstName)
            .Must(x => x.Length > 1)
            .WithMessage("First name must be at least 1 character")
            .Must(x => x.Length <= 30)
            .WithMessage("First name is too long. Max is 30 characters.");

        RuleFor(x => x.EmployeeCreateDto.LastName)
            .Must(x => x.Length > 1)
            .WithMessage("Last name must be at least 1 character")
            .Must(x => x.Length <= 30)
            .WithMessage("Last name is too long. Max is 30 characters."); ;

        RuleFor(x => x.EmployeeCreateDto.Email)
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            .WithMessage(x => $"{ x.EmployeeCreateDto.Email} is not a valid email address.");

        RuleFor(x => x.EmployeeCreateDto.DepartmentCode)
            .NotEmpty()
            .WithMessage("Department code is required.");
    }
}