﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CrudDemo.Data.Services.Internal
{
    internal class CrudDataService : ICrudDataService, IDisposable
    {
        private readonly DemoDbContext dbContext;

        public CrudDataService(DemoDbContext dbContext, 
            ILogger<ICrudDataService> logger, 
            IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository)
        {
            this.dbContext = dbContext;
            this.Employee = employeeRepository;
            this.Project = projectRepository;
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
