using CrudDemo.App.Dtos;
using CrudDemo.App.Project.Commands;
using CrudDemo.App.Project.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProjectApiController(IMediator mediator)
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
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProjectCreateDto projectCreateDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await this.mediator.Send(new CreateProjectCommand(projectCreateDto), cancellationToken);

                return CreatedAtRoute(nameof(GetProjectById), new { Id = result.ProjectId }, result);
            }

            return new JsonResult("Something went wrong.") { StatusCode = 500 };
        }
    }
}
