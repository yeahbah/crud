using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.App.Employee.Commands;
using CrudDemo.Data.Models;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Project.Commands;

public record UpdateProjectCommand(ProjectUpdateDto ProjectDto) : ICommand, IRequest
{
    
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly ICrudDataService crudDataService;
    private readonly IMapper mapper;

    public UpdateProjectCommandHandler(ICrudDataService crudDataService, IMapper mapper)
    {
        this.crudDataService = crudDataService;
        this.mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectEntity = this.mapper.Map<ProjectEntity>(request.ProjectDto);
        await this.crudDataService.Project.Upsert(projectEntity, cancellationToken);
        await this.crudDataService.CompleteAsync(cancellationToken);

        return Unit.Value;
    }
}