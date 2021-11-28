using CrudDemo.Data.Models.Entities;
using System;
namespace CrudDemo.Data.Services
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity>
    {
    }
}
