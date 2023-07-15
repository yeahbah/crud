using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudDemo.Data.Models;

[Table("EmployeeProject")]
public class EmployeeProjectEntity
{
    [Required]
    [ForeignKey(nameof(Employee))]
    public Guid EmployeeId { get; set; }

    [Required]
    [ForeignKey(nameof(Project))]
    public Guid ProjectId { get; set; }

    public virtual EmployeeEntity Employee { get; set; }
    public virtual ProjectEntity Project { get; set; }
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
            .HasOne(employee => employee.Employee)
            .WithMany(employee => employee.Projects)
            .HasForeignKey(employee => employee.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(project => project.Project)
            .WithMany(project => project.Employees)
            .HasForeignKey(project => project.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}