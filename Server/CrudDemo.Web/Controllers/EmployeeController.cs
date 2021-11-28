using System;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Dtos;
using CrudDemo.App.Employee.Commands;
using CrudDemo.App.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetEmployeeByIdQuery { Id = id }, cancellationToken);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeCreateDto newEmployee, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new CreateEmployeeCommand(newEmployee), cancellationToken);
            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = result.EmployeeId }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id, CancellationToken cancellationToken)
        {
            await this.mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
            return NoContent();
        }
    }
}