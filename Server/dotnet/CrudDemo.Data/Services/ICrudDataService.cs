using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.Data.Services
{
    public interface ICrudDataService
    {
        IEmployeeRepository Employee { get; }
        IProjectRepository Project { get; }
        IDepartmentRepository Department { get; set; }
        Task CompleteAsync(CancellationToken cancellationToken);
        void Dispose();
    }
}
