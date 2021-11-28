using AutoMapper;
using CrudDemo.App.Dtos;
using CrudDemo.Data.Models.Entities;

namespace CrudDemo.App.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Source -> Target
            CreateMap<EmployeeCreateDto, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeReadDto>();
            CreateMap<ProjectCreateDto, ProjectEntity>();
            CreateMap<ProjectEntity, ProjectReadDto>()
                .ForMember(x => x.CreatedByEmployeeName, opt => opt.MapFrom(src => src.Ref_CreatedByEmployee.FirstName + " " + src.Ref_CreatedByEmployee.LastName));

        }
    }
}