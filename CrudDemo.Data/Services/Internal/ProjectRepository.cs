using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrudDemo.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrudDemo.Data.Services.Internal
{
    internal class ProjectRepository : GenericRepository<ProjectEntity>, IProjectRepository
    {
        private readonly DemoDbContext dbContext;
        private readonly ILogger logger;

        public ProjectRepository(DemoDbContext dbContext, ILogger<IProjectRepository> logger) : base(dbContext, logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public override async Task<IEnumerable<ProjectEntity>> All()
        {
            try
            {
                return await this.dbContext.Projects
                    .Include(project => project.Ref_CreatedByEmployee)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"{typeof(ProjectRepository)} All() function error");
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
                this.logger.LogError(e, $"{typeof(ProjectRepository)} Upsert() function error.");
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var project = await dbSet.FirstOrDefaultAsync(x => x.ProjectId == id);
                if (project == null) return false;

                project.IsDeleted = 1;

                return true;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"{typeof(ProjectRepository)} Delete() function error.");
                return false;
            }
        }
    }
}
