using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<EmployeeEntity> Ref_ManyEmployees { get; set; }
    }
}
