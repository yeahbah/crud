using FluentValidation;

namespace CrudDemo.App.Project.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(c => c.ProjectCreateDto.Name).ProjectName();

        RuleFor(c => c.ProjectCreateDto.Description).ProjectDescription();
    }
}