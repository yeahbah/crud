using System;

namespace CrudDemo.App.Dtos;

public record ProjectCreateDto
{
    public string Name { get; init; }
    public string Description { get; init; }
}