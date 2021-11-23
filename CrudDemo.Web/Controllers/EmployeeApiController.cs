using System;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.App.Dtos;
using CrudDemo.App.Employee.Commands;
using CrudDemo.App.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeApiController(IMediator mediator)
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
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeCreateDto newEmployee, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await this.mediator.Send(new CreateEmployeeCommand(newEmployee), cancellationToken);
                return CreatedAtRoute(nameof(GetEmployeeById), new { result.Id }, result);
            }

            return new JsonResult("Oops something went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id, CancellationToken cancellationToken)
        {
            await this.mediator.Send(new DeleteEmployeeCommand { Id = id }, cancellationToken);
            return Ok();
        }
    }
}