using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;
using Riok.Mapperly.Abstractions;

namespace CrudDemo.App.Mappings;

[Mapper]
internal static partial class EmployeeMapping
{
    public static partial EmployeeEntity ToEntity(EmployeeCreateDto dto);
    public static partial void UpdateEntity(EmployeeUpdateDto dto, EmployeeEntity entity);
    
    [MapProperty("Department.Name", nameof(EmployeeReadDto.DepartmentName))]
    public static partial EmployeeReadDto ToDto(EmployeeEntity entity);

    [MapProperty("Project.Name", "ProjectName")]
    [MapProperty("Employee.FirstName", "EmployeeFirstName")]
    [MapProperty("Employee.LastName", "EmployeeLastName")]
    private static partial EmployeeProjectReadDto EmployeeProject(EmployeeProjectEntity entity);
}