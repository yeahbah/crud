using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrudDemo.WebApp.Models.EmployeeModel;

namespace CrudDemo.WebApp.Models
{
    public record ProjectModel
    {
        public Guid ProjectId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }

        public DateTime CreatedTimestamp { get; init; }

        public Guid CreatedByEmployeeId { get; init; }

        public string? CreatedByEmployeeName { get; init; }

        public EmployeeProject[]? Employees { get; set; }
    }
}
