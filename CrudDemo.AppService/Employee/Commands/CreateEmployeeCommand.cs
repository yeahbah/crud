using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CrudDemo.Data.Services;
using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;

namespace CrudDemo.App.Employee.Commands
{
    public record CreateEmployeeCommand(EmployeeCreateDto EmployeeCreateDto) : IRequest<EmployeeReadDto>
    {

    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeReadDto>
    {
        private readonly ICrudDataService crudDataService;
        private readonly IMapper mapper;

        public CreateEmployeeCommandHandler(ICrudDataService crudDataService, IMapper mapper)
        {
            this.crudDataService = crudDataService;
            this.mapper = mapper;
        }

        public async Task<EmployeeReadDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmployee = this.mapper.Map<EmployeeEntity>(request.EmployeeCreateDto);
            await this.crudDataService.Employee.Add(newEmployee);
            await this.crudDataService.CompleteAsync();

            return this.mapper.Map<EmployeeReadDto>(newEmployee);
        }
    }
}
