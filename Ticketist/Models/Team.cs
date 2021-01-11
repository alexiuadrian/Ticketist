using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class Team
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        [RegularExpression(@"[A-Z]{3}")]
        public string Code { get; set; }

        [Display(Name = "Name of Project")]
        public int? ProjectId { get; set; }
    }
}