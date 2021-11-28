using System;

namespace CrudDemo.App.Dtos
{
    public record ProjectReadDto
    {
        public Guid ProjectId { get; init; }
        public string Name { get; init; }

        public DateTime CreatedTimestamp { get; init; }

        public Guid CreatedByEmployeeId { get; init; }

        public string CreatedByEmployeeName { get; init; }
    }
}