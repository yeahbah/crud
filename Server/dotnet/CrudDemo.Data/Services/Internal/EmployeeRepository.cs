using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CrudDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrudDemo.Data.Services.Internal
{
    internal class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
    {
        private readonly ILogger logger;

        public EmployeeRepository(DemoDbContext dbContext, ILogger<IEmployeeRepository> logger) : base(dbContext, logger)
        {
            this.logger = logger;
        }

        public override Task<IQueryable<EmployeeEntity>> All()
        {
            try
            {
                return Task.FromResult(
                    dbSet
                        .TagWith("Get all employees")
                        .Include(employee => employee.Department)
                        .Include(employee => employee.Projects)
                        .ThenInclude(x => x.Project)
                        .AsQueryable());

            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "{Repo} All function error", typeof(EmployeeRepository));
                throw;
            }
        }

        public override async Task<EmployeeEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await this.dbSet
                .Include(employee => employee.Department)
                .Include(employee => employee.Projects)
                .FirstOrDefaultAsync(employee => employee.EmployeeId == id, cancellationToken: cancellationToken);
        }

        public override async Task<bool> Upsert(EmployeeEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await dbSet
                    .Where(x => x.EmployeeId == entity.EmployeeId)
                    .FirstOrDefaultAsync(cancellationToken);
                if (existingUser == null)
                    return await Add(entity, cancellationToken);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                existingUser.PhoneNumber = entity.PhoneNumber;

                return true;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "{Repo} Upsert function error.", typeof(EmployeeRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await dbSet
                    .Where(x => x.EmployeeId == id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (employee == null) return false;
                employee.IsDeleted = true;                

                return true;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "{Repo} Delete function error", typeof(EmployeeRepository));
                return false;
            }
        }
    }
}
