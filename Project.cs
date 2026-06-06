using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoard.Entities
{
    [Table("project_details", Schema = "master")]
    public class ProjectDetails
    {
        [Column("project_id")]
        [MaxLength(36)]
        public string ProjectId { get; set; }

        [Column("project_name")]
        [Required]
        [MaxLength(64)]
        public string ProjectName { get; set; }

        [Column("project_start_date")]
        public DateTime? ProjectStartDate { get; set; }

        [Column("project_end_date")]
        public DateTime? ProjectEndDate { get; set; }
    }
}