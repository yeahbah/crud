using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models.Entities;
using CrudDemo.Data.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.App.Project.Commands
{
    public record CreateProjectCommand(ProjectCreateDto ProjectCreateDto) : IRequest<ProjectReadDto>
    {
        
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectReadDto>
    {
        private readonly ICrudDataService crudDataService;
        private readonly IMapper mapper;

        public CreateProjectCommandHandler(ICrudDataService crudDataService, IMapper mapper)
        {
            this.crudDataService = crudDataService;
            this.mapper = mapper;
        }

        public async Task<ProjectReadDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = this.mapper.Map<ProjectEntity>(request.ProjectCreateDto);
            newProject.CreatedTimestamp = DateTime.Now;
            newProject.CreatedByEmployeeId = new Guid("cd765367-1005-4e7a-55b1-08d9b12e39b9");

            if (!(await this.crudDataService.Project.Add(newProject)))
                throw new Exception("Unable to create new project");

            await this.crudDataService.CompleteAsync();
            return this.mapper.Map<ProjectReadDto>(newProject);
        }
    }
}
