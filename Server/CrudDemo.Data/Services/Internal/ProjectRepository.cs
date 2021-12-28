using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.Data.Models;
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

        public override Task<IQueryable<ProjectEntity>> All()
        {
            try
            {
                return Task.FromResult(
                    this.dbContext.Projects
                        .AsNoTracking()
                        .Include(project => project.Ref_CreatedByEmployee)
                        .Where(project => project.IsDeleted != 1));
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"{typeof(ProjectRepository)} All() function error");
                throw;
            }
        }

        public override async Task<ProjectEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await this.dbContext.Projects
                .AsNoTracking()
                .Include(project => project.Ref_CreatedByEmployee)
                .FirstOrDefaultAsync(project => project.ProjectId == id && project.IsDeleted != 1, cancellationToken);

        }

        public override async Task<bool> Upsert(ProjectEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var existingProject = await dbSet
                    .FirstOrDefaultAsync(x => x.ProjectId == entity.ProjectId && x.IsDeleted != 1, cancellationToken);

                if (existingProject == null)
                    return await Add(entity, cancellationToken);

                existingProject.Name = entity.Name;

                return true;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"{typeof(ProjectRepository)} Upsert() function error.");
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var project = await dbSet
                    .FirstOrDefaultAsync(x => x.ProjectId == id, cancellationToken);

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
