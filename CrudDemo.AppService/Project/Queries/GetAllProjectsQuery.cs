using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.App.Project.Queries
{
    public record GetAllProjectsQuery : IRequest<IEnumerable<ProjectReadDto>>
    {
        
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectReadDto>>
    {
        private readonly ICrudDataService crudDataService;
        private readonly IMapper mapper;

        public GetAllProjectsQueryHandler(ICrudDataService crudDataService, IMapper mapper)
        {
            this.crudDataService = crudDataService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProjectReadDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await this.crudDataService.Project.All();

            return this.mapper.Map<IEnumerable<ProjectReadDto>>(result);

        }
    }
}
