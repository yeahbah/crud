using System;
using CrudDemo.Data.Models;

namespace CrudDemo.App.Dtos;

public record EmployeeProjectReadDto
{
    public Guid EmployeeId { get; init; }
    
    public Guid ProjectId { get; init; }
    public string ProjectName { get; init; }
    public string EmployeeFirstName { get; init; }
    public string EmployeeLastName { get; set; }
}