using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProject.Entities
{
    [Table("task_details", Schema = "master")]
    public class TaskDetails
    {
        [Column("task_id")]
        [MaxLength(36)]
        public string TaskId { get; set; }

        [Column("task_name")]
        [MaxLength(64)]
        public string TaskName { get; set; }

        [Column("project_id")]
        [MaxLength(36)]
        public string TaskId { get; set; }

        [Column("user_id")]
        [Required]
        [MaxLength(36)]
        public string UserName { get; set; }

        [Column("task_description")]
        [Required]
        [MaxLength(256)]
        public string TaskDescription { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_by")]
        [Required]
        [MaxLength(256)]
        public string CreatedBy { get; set; }

        [Column("created_time")]
        public DateTime CreatedTime { get; set; }

        [Column("updated_by")]
        [MaxLength(256)]
        public string? UpdatedBy { get; set; }

        [Column("updated_time")]
        public DateTime? UpdatedTime { get; set; }

        [Column("task_status")]
        [Required]
        [MaxLength(64)]
        public string TaskStatus { get; set; }

        [Column("is_deleted")]
        public bool? IsDeleted { get; set; }

        [Column("del_dtimes")]
        public DateTime? DelDtimes { get; set; }
    }
}