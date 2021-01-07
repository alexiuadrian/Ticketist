using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Mapping;

namespace Ticketist.Models
{
    public class Project
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [EndDateLowerThanStartDateValidation]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [EndDateLowerThanStartDateValidation]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Name Of Organization")]
        public int OrganizationId { get; set; }
    }
}