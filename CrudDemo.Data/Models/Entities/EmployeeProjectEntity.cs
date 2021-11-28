using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDemo.Data.Models.Entities
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
}