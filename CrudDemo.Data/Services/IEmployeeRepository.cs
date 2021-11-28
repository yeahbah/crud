using System;
using CrudDemo.Data.Models.Entities;

namespace CrudDemo.Data.Services
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeEntity>
    {
    }
}
