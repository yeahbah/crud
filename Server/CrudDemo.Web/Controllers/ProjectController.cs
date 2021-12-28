using CrudDemo.App.Dtos;
using CrudDemo.App.Project.Commands;
using CrudDemo.App.Project.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace CrudDemo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetAllProjectsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetProjectById))]
        public async Task<IActionResult> GetProjectById(Guid id, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetProjectByIdQuery(id), cancellationToken);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProjectCreateDto projectCreateDto, CancellationToken cancellationToken)
        {
            
            var result = await this.mediator.Send(new CreateProjectCommand(projectCreateDto), cancellationToken);

            return CreatedAtRoute(nameof(GetProjectById), new { Id = result.ProjectId }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new DeleteProjectCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProjectUpdateDto projectUpdateDto, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new UpdateProjectCommand(projectUpdateDto), cancellationToken);
            return NoContent();
        }
    }
}
