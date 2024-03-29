using System.Linq;
//using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;

namespace CrudDemo.App.Mappings;

// public class MappingProfile : Profile
// {
//     public MappingProfile()
//     {
//         // Source -> Target
//         CreateMap<EmployeeCreateDto, EmployeeEntity>();
//         CreateMap<EmployeeUpdateDto, EmployeeEntity>();
//         CreateMap<EmployeeEntity, EmployeeReadDto>()
//             .ForMember(x => x.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
//             .ForMember(x => x.Projects, opt => opt.MapFrom(src => src.Projects));
//         
//         CreateMap<ProjectCreateDto, ProjectEntity>();
//         CreateMap<ProjectUpdateDto, ProjectEntity>();        
//         CreateMap<ProjectEntity, ProjectReadDto>()
//             .ForMember(x => x.CreatedByEmployeeName, opt => opt.MapFrom(src => src.CreatedByEmployee.FirstName + " " + src.CreatedByEmployee.LastName))
//             .ForMember(x => x.Employees, opt => opt.MapFrom(src => src.Employees));
//         
//         CreateMap<EmployeeProjectEntity, EmployeeProjectReadDto>()
//             .ForMember(x => x.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
//             .ForMember(x => x.EmployeeFirstName, opt => opt.MapFrom(src => src.Employee.FirstName))
//             .ForMember(x => x.EmployeeLastName, opt => opt.MapFrom(src => src.Employee.LastName));
//         
//     }
// }