using System;
using System.Collections.Generic;

namespace CrudDemo.App.Dtos;

public record ProjectReadDto
{
    public Guid ProjectId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

    public DateTimeOffset CreatedTimestamp { get; init; }

    public Guid CreatedByEmployeeId { get; init; }

    public string CreatedByEmployeeName { get; init; }
    
    public ICollection<EmployeeProjectReadDto> Employees { get; init; }
}