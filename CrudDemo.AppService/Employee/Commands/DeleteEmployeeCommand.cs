using System;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Commands
{
    public record DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; init; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly ICrudDataService crudDataService;

        public DeleteEmployeeCommandHandler(ICrudDataService unitOfWork)
        {
            this.crudDataService = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //var employe = await this.unitOfWork.Employee.GetById(request.Id);
            //if (employe == null)
            //{
            //    return BadRequest
            //}
            if (await this.crudDataService.Employee.Delete(request.Id))
            {
                await this.crudDataService.CompleteAsync();
            }

            return Unit.Value;
        }
    }
}
