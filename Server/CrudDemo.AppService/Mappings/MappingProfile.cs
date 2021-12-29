using System.Linq;
using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;

namespace CrudDemo.App.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Source -> Target
        CreateMap<EmployeeCreateDto, EmployeeEntity>();
        CreateMap<EmployeeUpdateDto, EmployeeEntity>();
        CreateMap<EmployeeEntity, EmployeeReadDto>()
            .ForMember(x => x.DepartmentName, opt => opt.MapFrom(src => src.Ref_Department.Name))
            .ForMember(x => x.Projects, opt => opt.MapFrom(src => src.Ref_Projects));
        
        CreateMap<ProjectCreateDto, ProjectEntity>();
        CreateMap<ProjectUpdateDto, ProjectEntity>();        
        CreateMap<ProjectEntity, ProjectReadDto>()
            .ForMember(x => x.CreatedByEmployeeName, opt => opt.MapFrom(src => src.Ref_CreatedByEmployee.FirstName + " " + src.Ref_CreatedByEmployee.LastName))
            .ForMember(x => x.Employees, opt => opt.MapFrom(src => src.Ref_ManyEmployees));
        
        CreateMap<EmployeeProjectEntity, EmployeeProjectReadDto>()
            .ForMember(x => x.ProjectName, opt => opt.MapFrom(src => src.Ref_Project.Name))
            .ForMember(x => x.EmployeeName, opt => opt.MapFrom(src => $"{src.Ref_Employee.FirstName} {src.Ref_Employee.LastName}"));
        
    }
}