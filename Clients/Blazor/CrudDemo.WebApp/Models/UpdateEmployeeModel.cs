using System.ComponentModel.DataAnnotations;

namespace CrudDemo.WebApp.Models
{
    public class UpdateEmployeeModel
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(30)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? DepartmentCode { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
