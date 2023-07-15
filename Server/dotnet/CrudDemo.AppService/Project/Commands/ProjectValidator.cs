using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudDemo.App.Project.Commands;

public static class ProjectValidator
{
    public static IRuleBuilderOptions<T, string> ProjectName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(c => c.Length > 3)
            .WithMessage("Project name must be at least 10 characters long.")
            .Must(c => c.Length <= 100)
            .WithMessage("Project name must not be longer than 100 characters.");
    }

    public static IRuleBuilder<T, string> ProjectDescription<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(c => c.Length <= 2000)
            .WithMessage("Project description exceeded length limit");
    }
}