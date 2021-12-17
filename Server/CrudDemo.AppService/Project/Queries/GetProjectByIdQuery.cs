using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.App.Project.Queries
{
    public record GetProjectByIdQuery(Guid Id) : IRequest<ProjectReadDto>
    {

    }

    public class GetProjectByIdQuerHandler : IRequestHandler<GetProjectByIdQuery, ProjectReadDto>
    {
        private readonly ICrudDataService crudDataService;
        private readonly IMapper mapper;

        public GetProjectByIdQuerHandler(ICrudDataService crudDataService, IMapper mapper)
        {
            this.crudDataService = crudDataService;
            this.mapper = mapper;
        }

        public async Task<ProjectReadDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await this.crudDataService.Project.GetById(request.Id, cancellationToken);
            return this.mapper.Map<ProjectReadDto>(result);
        }
    }

}
