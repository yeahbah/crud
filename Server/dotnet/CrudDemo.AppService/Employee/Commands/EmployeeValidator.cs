using FluentValidation;

namespace CrudDemo.App.Employee.Commands;

public static class EmployeeValidator
{
    public static IRuleBuilderOptions<T, string> EmployeeFirstName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(x => x.Length > 1)
            .WithMessage("First name must be at least 1 character")
            .Must(x => x.Length <= 30)
            .WithMessage("First name is too long. Max is 30 characters.");
    }

    public static IRuleBuilderOptions<T, string> EmployeeLastName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(x => x.Length > 1)
            .WithMessage("Last name must be at least 1 character")
            .Must(x => x.Length <= 30)
            .WithMessage("Last name is too long. Max is 30 characters."); ;
    }

    public static IRuleBuilderOptions<T, string> EmployeeEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            .WithMessage(x => "Invalid email address.");
    }

    public static IRuleBuilder<T, string> EmployeeDepartmentCode<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage("Department code is required.");
    }
        
}