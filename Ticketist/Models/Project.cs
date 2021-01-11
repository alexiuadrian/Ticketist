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
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$")]
        [EndDateLowerThanStartDateValidation]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$")]
        [EndDateLowerThanStartDateValidation]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Name Of Organization")]
        public int OrganizationId { get; set; }
    }
}