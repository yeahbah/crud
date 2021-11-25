using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrudDemo.Data.Services.Internal
{
    internal class ProjectRepository : GenericRepository<ProjectEntity>, IProjectRepository
    {
        private readonly ILogger logger;

        public ProjectRepository(DemoDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
            this.logger = logger;
        }

        public override async Task<IEnumerable<ProjectEntity>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProjectEntity>();
            }
        }

        public override async Task<bool> Upsert(ProjectEntity entity)
        {
            try
            {
                var existingProject = await dbSet
                    .FirstOrDefaultAsync(x => x.ProjectId == entity.ProjectId);
                if (existingProject == null)
                    return await Add(entity);

                existingProject.Name = entity.Name;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
