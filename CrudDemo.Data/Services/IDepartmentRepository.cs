using CrudDemo.Data.Models;
using System;
namespace CrudDemo.Data.Services
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity>
    {
    }
}
