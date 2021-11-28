using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDemo.Data.Models.Entities
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

        [Required]
        public DateTime CreatedTimestamp { get; set; }

        [Required]
        public Guid CreatedByEmployeeId { get; set; }

        public ushort? IsDeleted { get; set; }

        public DateTime? UpdatedTimestamp { get; set; }
        public Guid? UpdatedByEmployeeId { get; set; }

        public virtual EmployeeEntity Ref_CreatedByEmployee { get; set; }

        public virtual ICollection<EmployeeProjectEntity> Ref_ManyEmployees { get; set; }
    }
}
