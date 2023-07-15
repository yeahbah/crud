using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Dtos;
using CrudDemo.App.Mappings;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Commands;

public record UpdateEmployeeCommand(EmployeeUpdateDto EmployeeUpdateDto) : ICommand, IRequest<Unit>;

public class EmployeeUpdateCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly ICrudDataService crudDataService;

    public EmployeeUpdateCommandHandler(ICrudDataService crudDataService)
    {
        this.crudDataService = crudDataService;
    }
    
    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var updateEmployee = EmployeeMapping.ToEntity(request.EmployeeUpdateDto);
        await crudDataService.Employee.Upsert(updateEmployee, cancellationToken);
        await crudDataService.CompleteAsync(cancellationToken);
        return Unit.Value;
    }
}