using System;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Commands
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest;

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly ICrudDataService crudDataService;

        public DeleteEmployeeCommandHandler(ICrudDataService unitOfWork)
        {
            this.crudDataService = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await this.crudDataService.Employee.Delete(request.Id))
            {
                await this.crudDataService.CompleteAsync();
            }

            return Unit.Value;
        }
    }
}
