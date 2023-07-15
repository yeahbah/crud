using CrudDemo.Data.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrudDemo.Data.Services.Internal
{
    internal class DepartmentRepository : GenericRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(DemoDbContext dbContext, ILogger logger) 
            : base(dbContext, logger)
        {
        }

        public override Task<IQueryable<DepartmentEntity>> All()
        {
            return Task.FromResult(dbSet.AsQueryable());
        }

        public async Task<DepartmentEntity> GetByCode(string departmentCode, CancellationToken cancellationToken)
        {
            return await dbSet
                .Where(department => department.DepartmentCode == departmentCode)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> Delete(string departmentCode, CancellationToken cancellationToken)
        {
            var department = await dbSet
                .Where(department => department.DepartmentCode == departmentCode)
                .FirstOrDefaultAsync(cancellationToken);

            if (department == null) return false;
            department.IsDeleted = true;

            return true;
        }

        public override async Task<bool> Upsert(DepartmentEntity entity, CancellationToken cancellationToken)
        {
            var existingDepartment = await dbSet
                .Where(d => d.DepartmentCode == entity.DepartmentCode)
                .FirstOrDefaultAsync(cancellationToken);

            if (existingDepartment == null)
                return await Add(entity, cancellationToken);

            existingDepartment.DepartmentCode = entity.DepartmentCode;
            existingDepartment.Name = entity.Name;

            return true;
        }
    }
}
