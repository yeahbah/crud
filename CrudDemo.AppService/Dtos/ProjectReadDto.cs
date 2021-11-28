using System;

namespace CrudDemo.App.Dtos
{
    public class ProjectReadDto
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public Guid CreatedByEmployeeId { get; set; }

        public string CreatedByEmployeeName { get; set; }
    }
}