using FluentValidation;

namespace CrudDemo.App.Employee.Commands;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeUpdateDto.FirstName).EmployeeFirstName();

        RuleFor(x => x.EmployeeUpdateDto.LastName).EmployeeLastName();

        RuleFor(x => x.EmployeeUpdateDto.Email).EmployeeEmail();

        RuleFor(x => x.EmployeeUpdateDto.DepartmentCode).EmployeeDepartmentCode();
    }    
}