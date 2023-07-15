using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Employee.Commands;
using CrudDemo.App.Mappings;

namespace CrudDemo.App.Project.Commands;

public record CreateProjectCommand(ProjectCreateDto ProjectCreateDto) : ICommand, IRequest<ProjectReadDto>
{
        
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectReadDto>
{
    private readonly ICrudDataService crudDataService;

    public CreateProjectCommandHandler(ICrudDataService crudDataService)
    {
        this.crudDataService = crudDataService;
    }

    public async Task<ProjectReadDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var createdBy = (await this.crudDataService.Employee.All())
            .Single(e => e.FirstName == "System");

        var newProject = ProjectMapping.ToEntity(request.ProjectCreateDto);
        newProject.CreatedTimestamp = DateTime.Now;
        newProject.CreatedByEmployeeId = createdBy.EmployeeId;

        if (!(await this.crudDataService.Project.Add(newProject, cancellationToken)))
            throw new Exception("Unable to create new project");

        await this.crudDataService.CompleteAsync(cancellationToken);
        return ProjectMapping.ToDto(newProject);
    }
}