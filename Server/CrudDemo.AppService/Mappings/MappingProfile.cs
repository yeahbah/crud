using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models;

namespace CrudDemo.App.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Source -> Target
            CreateMap<EmployeeCreateDto, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeReadDto>()
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(src => src.Ref_Department.Name));
            CreateMap<ProjectCreateDto, ProjectEntity>();
            CreateMap<ProjectEntity, ProjectReadDto>()
                .ForMember(x => x.CreatedByEmployeeName, opt => opt.MapFrom(src => src.Ref_CreatedByEmployee.FirstName + " " + src.Ref_CreatedByEmployee.LastName));

        }
    }
}