using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudDemo.Data.Models
{
    [Table("Department")]
    public class DepartmentEntity
    {
        [Key]
        [Required]
        [MaxLength(5)]
        public string DepartmentCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; }
    }

    internal class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);
            
            builder
                .HasData(
                    new DepartmentEntity
                    {
                        DepartmentCode = "IT",
                        Name = "Information Technology"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "LOG",
                        Name = "Logistics"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "ENG",
                        Name = "Engineering"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "SUP",
                        Name = "Tech Support"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "RKT",
                        Name = "Rockets"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "BOARD",
                        Name = "Leadership"
                    }
                );
        }
    }
}
