using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CrudDemo.App.Project.Queries;

public record GetAllProjectsQuery : IRequest<IEnumerable<ProjectReadDto>>
{
        
}

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectReadDto>>
{
    private readonly ICrudDataService crudDataService;

    public GetAllProjectsQueryHandler(ICrudDataService crudDataService)
    {
        this.crudDataService = crudDataService;
    }

    public async Task<IEnumerable<ProjectReadDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var result = await this.crudDataService.Project
            .All()
            .GetAwaiter()
            .GetResult()
            .ToListAsync(cancellationToken);

        return result.Select(ProjectMapping.ToDto);

    }
}