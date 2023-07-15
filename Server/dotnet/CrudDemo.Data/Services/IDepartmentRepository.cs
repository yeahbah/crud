using CrudDemo.Data.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.Data.Services
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity>
    {
        Task<DepartmentEntity> GetByCode(string departmentCode, CancellationToken cancellationToken);
        Task<bool> Delete(string departmentCode, CancellationToken cancellationToken);
    }
}
