using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;
using Riok.Mapperly.Abstractions;

namespace CrudDemo.App.Mappings;

[Mapper]
public static partial class ProjectMapping
{
    public static partial ProjectEntity ToEntity(ProjectCreateDto dto);
    public static partial ProjectEntity ToEntity(ProjectUpdateDto dto);
    public static partial ProjectReadDto ToDto(ProjectEntity entity);
}