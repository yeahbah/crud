using CrudDemo.Data.Models;
using Microsoft.Extensions.Logging;
using System;
namespace CrudDemo.Data.Services.Internal
{
    internal class DepartmentRepository : GenericRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(DemoDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
