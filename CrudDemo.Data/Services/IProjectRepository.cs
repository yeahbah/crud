using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrudDemo.Data.Models.Entities;

namespace CrudDemo.Data.Services
{
    public interface IProjectRepository : IGenericRepository<ProjectEntity>
    {
        
    }
}
