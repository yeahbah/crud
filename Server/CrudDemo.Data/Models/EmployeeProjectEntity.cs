using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudDemo.Data.Models
{
    [Table("EmployeeProject")]
    public class EmployeeProjectEntity
    {
        [Required]
        [ForeignKey(nameof(Ref_Employee))]
        public Guid EmployeeId { get; set; }

        [Required]
        [ForeignKey(nameof(Ref_Project))]
        public Guid ProjectId { get; set; }

        public virtual EmployeeEntity Ref_Employee { get; set; }
        public virtual ProjectEntity Ref_Project { get; set; }
    }

    internal class EmployeeProjectEntityConfiguration : IEntityTypeConfiguration<EmployeeProjectEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectEntity> builder)
        {
            // EF 6 can do this automatically for you but
            // I don't like the generated db objects
            builder
                .HasKey(key => new {key.EmployeeId, key.ProjectId});
            builder
                .HasOne(employee => employee.Ref_Employee)
                .WithMany(employee => employee.Ref_Projects)
                .HasForeignKey(employee => employee.EmployeeId);
            builder
                .HasOne(project => project.Ref_Project)
                .WithMany(project => project.Ref_ManyEmployees)
                .HasForeignKey(project => project.ProjectId);
        }
    }
}