using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Commands;
 
public record UpdateEmployeeCommand(EmployeeUpdateDto EmployeeUpdateDto) : ICommand, IRequest<Unit>
{
    
}

public class EmployeeUpdateCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly ICrudDataService crudDataService;
    private readonly IMapper mapper;

    public EmployeeUpdateCommandHandler(ICrudDataService crudDataService, IMapper mapper)
    {
        this.crudDataService = crudDataService;
        this.mapper = mapper;   
    }
    
    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var updateEmployee = this.mapper.Map<EmployeeEntity>(request.EmployeeUpdateDto);
        await this.crudDataService.Employee.Upsert(updateEmployee, cancellationToken);
        await this.crudDataService.CompleteAsync(cancellationToken);
        return Unit.Value;
    }
}