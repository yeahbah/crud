using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Services;
using MediatR;

namespace CrudDemo.App.Employee.Queries
{
    public record GetEmployeeByIdQuery : IRequest<EmployeeReadDto>
    {
        public Guid Id { get; init; }
    }

    public class GetemployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeReadDto>
    {
        private readonly ICrudDataService unitOfWork;
        private readonly IMapper mapper;

        public GetemployeeByIdQueryHandler(ICrudDataService unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<EmployeeReadDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await this.unitOfWork.Employee.GetById(request.Id, cancellationToken);
            return this.mapper.Map<EmployeeReadDto>(result);
        }
    }
}
