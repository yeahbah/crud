using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CrudDemo.Data.Services;
using CrudDemo.App.Dtos;
using CrudDemo.App.Mappings;
using CrudDemo.Data.Models;

namespace CrudDemo.App.Employee.Commands;

public record CreateEmployeeCommand(EmployeeCreateDto EmployeeCreateDto) : ICommand, IRequest<EmployeeReadDto>
{

}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeReadDto>
{
    private readonly ICrudDataService crudDataService;

    public CreateEmployeeCommandHandler(ICrudDataService crudDataService)
    {
        this.crudDataService = crudDataService;
    }

    public async Task<EmployeeReadDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var newEmployee = EmployeeMapping.ToEntity(request.EmployeeCreateDto);// this.mapper.Map<EmployeeEntity>(request.EmployeeCreateDto);
        await crudDataService.Employee.Add(newEmployee, cancellationToken);
        await crudDataService.CompleteAsync(cancellationToken);

        return EmployeeMapping.ToDto(newEmployee);
    }
}