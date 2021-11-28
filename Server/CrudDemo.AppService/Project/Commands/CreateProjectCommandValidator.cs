using FluentValidation;

namespace CrudDemo.App.Project.Commands
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(c => c.ProjectCreateDto.Name)
                .Must(c => c.Length > 10)
                .WithMessage("Project name must be at least 10 characters long.")
                .Must(c => c.Length <= 100)
                .WithMessage("Project name must not be longer than 100 characters.");

        }
    }
}
