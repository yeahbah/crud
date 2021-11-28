using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDemo.Data.Models.Entities
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public string DepartmentCode { get; set; }

        public ushort? IsDeleted { get; set; }

        public DepartmentEntity Ref_Department { get; set; }

        public virtual ICollection<EmployeeProjectEntity> Ref_Projects { get; set; }

        public virtual ICollection<ProjectEntity> Ref_CreatedProjects { get; set; }

    }
}
