using CrudDemo.Data.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.App.Project.Commands;

public record DeleteProjectCommand(Guid Id) : IRequest;
   
public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly ICrudDataService crudDataService;

    public DeleteProjectCommandHandler(ICrudDataService crudDataService)
    {
        this.crudDataService = crudDataService;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        if (await this.crudDataService.Project.Delete(request.Id, cancellationToken))
        {
            await this.crudDataService.CompleteAsync(cancellationToken);
        }

        return Unit.Value;

    }
}