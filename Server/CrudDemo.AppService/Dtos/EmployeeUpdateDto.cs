using System;

namespace CrudDemo.App.Dtos;

public record EmployeeUpdateDto : EmployeeCreateDto
{
    public Guid EmployeeId { get; init; }
}