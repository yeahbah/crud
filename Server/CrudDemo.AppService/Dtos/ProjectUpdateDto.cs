using System;

namespace CrudDemo.App.Dtos;

public class ProjectUpdateDto
{
    public Guid Guid { get; set; }
    public string Name { get; init; }
    public string Description { get; init; }
}