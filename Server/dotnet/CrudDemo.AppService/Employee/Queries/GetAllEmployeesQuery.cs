using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Dtos;
using CrudDemo.App.Mappings;
using CrudDemo.Data.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudDemo.App.Employee.Queries;

public record GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeReadDto>>
{
        
}

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeReadDto>>
{
    private readonly ICrudDataService _crudDataService;

    public GetAllEmployeesQueryHandler(ICrudDataService crudDataService)
    {
        this._crudDataService = crudDataService;
    }

    public async Task<IEnumerable<EmployeeReadDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = await this._crudDataService.Employee
            .All()
            .GetAwaiter()
            .GetResult()
            .Where(employee => employee.LastName != "System")
            .ToListAsync(cancellationToken);
        return result.Select(EmployeeMapping.ToDto);// this.mapper.Map<IEnumerable<EmployeeReadDto>>(result);
    }
}