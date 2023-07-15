using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Mappings;

namespace CrudDemo.App.Project.Queries;

public record GetProjectByIdQuery(Guid Id) : IRequest<ProjectReadDto>
{

}

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectReadDto>
{
    private readonly ICrudDataService crudDataService;

    public GetProjectByIdQueryHandler(ICrudDataService crudDataService)
    {
        this.crudDataService = crudDataService;
    }

    public async Task<ProjectReadDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await this.crudDataService.Project.GetById(request.Id, cancellationToken);
        return ProjectMapping.ToDto(result);
    }
}