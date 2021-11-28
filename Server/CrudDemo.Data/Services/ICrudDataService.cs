using System;
using System.Threading.Tasks;

namespace CrudDemo.Data.Services
{
    public interface ICrudDataService
    {
        IEmployeeRepository Employee { get; }
        IProjectRepository Project { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
