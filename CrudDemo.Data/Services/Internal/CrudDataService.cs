using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CrudDemo.Data.Services.Internal
{
    internal class CrudDataService : ICrudDataService, IDisposable
    {
        private readonly DemoDbContext dbContext;
        private readonly ILogger logger;

        public CrudDataService(DemoDbContext dbContext, ILoggerFactory loggerFactory)
        {
            this.dbContext = dbContext;
            this.logger = loggerFactory.CreateLogger("logs");

            Employee = new EmployeeRepository(dbContext, this.logger);
            Project = new ProjectRepository(dbContext, this.logger);
        }

        public IEmployeeRepository Employee { get; private set; }
        public IProjectRepository Project { get; private set; }

        public async Task CompleteAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
