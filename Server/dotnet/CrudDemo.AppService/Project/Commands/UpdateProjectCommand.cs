using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Dtos;
using CrudDemo.App.Employee.Commands;
using CrudDemo.App.Mappings;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Project.Commands;

public record UpdateProjectCommand(ProjectUpdateDto ProjectDto) : ICommand, IRequest
{
    
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly ICrudDataService _crudDataService;

    public UpdateProjectCommandHandler(ICrudDataService crudDataService)
    {
        this._crudDataService = crudDataService;
    }
    
    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectEntity = ProjectMapping.ToEntity(request.ProjectDto);
        await this._crudDataService.Project.Upsert(projectEntity, cancellationToken);
        await this._crudDataService.CompleteAsync(cancellationToken);
    }
}