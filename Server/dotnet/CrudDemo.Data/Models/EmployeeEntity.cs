using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudDemo.Data.Models
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

        public DateOnly BirthDate { get; set; }

        public string DepartmentCode { get; set; }

        public bool IsDeleted { get; set; }

        public DepartmentEntity Department { get; set; }

        public virtual ICollection<EmployeeProjectEntity> Projects { get; set; }

        public virtual ICollection<ProjectEntity> CreatedProjects { get; set; }

    }

    internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);
            builder
                .HasOne(employee => employee.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey(employee => employee.DepartmentCode)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
