using System;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Dtos;
using CrudDemo.App.Mappings;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Queries;

public record GetEmployeeByIdQuery : IRequest<EmployeeReadDto>
{
    public Guid Id { get; init; }
}

public class GetemployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeReadDto>
{
    private readonly ICrudDataService _unitOfWork;

    public GetemployeeByIdQueryHandler(ICrudDataService unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<EmployeeReadDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await this._unitOfWork.Employee.GetById(request.Id, cancellationToken);
        return EmployeeMapping.ToDto(result);// this.mapper.Map<EmployeeReadDto>(result);
    }
}