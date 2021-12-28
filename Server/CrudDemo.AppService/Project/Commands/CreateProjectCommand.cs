using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;
using CrudDemo.Data.Services;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Employee.Commands;

namespace CrudDemo.App.Project.Commands;

public record CreateProjectCommand(ProjectCreateDto ProjectCreateDto) : ICommand, IRequest<ProjectReadDto>
{
        
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectReadDto>
{
    private readonly ICrudDataService crudDataService;
    private readonly IMapper mapper;

    public CreateProjectCommandHandler(ICrudDataService crudDataService, IMapper mapper)
    {
        this.crudDataService = crudDataService;
        this.mapper = mapper;
    }

    public async Task<ProjectReadDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var createdBy = (await this.crudDataService.Employee.All())
            .Single(e => e.FirstName == "System");
        
        var newProject = this.mapper.Map<ProjectEntity>(request.ProjectCreateDto);
        newProject.CreatedTimestamp = DateTime.Now;
        newProject.CreatedByEmployeeId = createdBy.EmployeeId;

        if (!(await this.crudDataService.Project.Add(newProject, cancellationToken)))
            throw new Exception("Unable to create new project");

        await this.crudDataService.CompleteAsync(cancellationToken);
        return this.mapper.Map<ProjectReadDto>(newProject);
    }
}