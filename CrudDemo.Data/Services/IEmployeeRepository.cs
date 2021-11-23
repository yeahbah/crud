using System;
using CrudDemo.Data.Models;

namespace CrudDemo.Data.Services
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeEntity>
    {
    }
}
