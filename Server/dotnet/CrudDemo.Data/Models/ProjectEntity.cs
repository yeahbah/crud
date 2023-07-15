using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudDemo.Data.Models
{
    [Table("Project")]
    public class ProjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedTimestamp { get; set; }

        [Required]
        public Guid CreatedByEmployeeId { get; set; }

        public ushort? IsDeleted { get; set; }

        public DateTimeOffset? UpdatedTimestamp { get; set; }
        public Guid? UpdatedByEmployeeId { get; set; }

        public virtual EmployeeEntity CreatedByEmployee { get; set; }

        public virtual ICollection<EmployeeProjectEntity> Employees { get; set; }
    }

    internal class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder
                .HasOne(project => project.CreatedByEmployee)
                .WithMany(employee => employee.CreatedProjects)
                .HasForeignKey(project => project.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
