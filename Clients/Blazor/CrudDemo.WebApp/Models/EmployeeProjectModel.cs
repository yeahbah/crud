namespace CrudDemo.WebApp.Models
{
    public record EmployeeProject
    {
        public Guid EmployeeId { get; init; }
        public Guid ProjectId { get; init; }
        public string? ProjectName { get; init; }
        public string? EmployeeFirstName {get; init; }
        public string? EmployeeLastName { get; init; }
    }

}
