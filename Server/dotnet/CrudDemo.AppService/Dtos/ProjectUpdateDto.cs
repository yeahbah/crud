using System;

namespace CrudDemo.App.Dtos;

public class ProjectUpdateDto
{
    public Guid ProjectId { get; set; }
    public string Name { get; init; }
    public string Description { get; init; }
}