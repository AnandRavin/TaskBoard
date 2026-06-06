uusing System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoard.Entities
{
    [Table("user_details", Schema = "master")]
    public class UserDetails
    {
        [Column("user_id")]
        [MaxLength(36)]
        public string UserId { get; set; }

        [Column("user_name")]
        [Required]
        [MaxLength(64)]
        public string UserName { get; set; }

        [Column("project_id")]
        [Required]
        [MaxLength(36)]
        public string ProjectId { get; set; }

        [Column("reporting_to")]
        [Required]
        [MaxLength(36)]
        public string ReportingTo { get; set; }

  
    }
}