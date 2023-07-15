using FluentValidation;

namespace CrudDemo.App.Employee.Commands;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeCreateDto.FirstName).EmployeeFirstName();

        RuleFor(x => x.EmployeeCreateDto.LastName).EmployeeLastName();

        RuleFor(x => x.EmployeeCreateDto.Email).EmployeeEmail();

        RuleFor(x => x.EmployeeCreateDto.DepartmentCode).EmployeeDepartmentCode();
    }
}