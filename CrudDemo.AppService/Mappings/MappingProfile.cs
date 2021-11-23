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
            CreateMap<EmployeeEntity, EmployeeReadDto>();
        }
    }
}