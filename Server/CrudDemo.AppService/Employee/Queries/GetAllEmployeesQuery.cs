using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Queries
{
    public record GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeReadDto>>
    {
        
    }

    public class GetAllEmployeessQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeReadDto>>
    {
        private readonly ICrudDataService crudDataService;
        private readonly IMapper mapper;

        public GetAllEmployeessQueryHandler(ICrudDataService crudDataService, IMapper mapper)
        {
            this.crudDataService = crudDataService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeReadDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await this.crudDataService.Employee.All();
            return this.mapper.Map<IEnumerable<EmployeeReadDto>>(result);
        }
    }
}
