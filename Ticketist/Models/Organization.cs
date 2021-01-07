using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Ticketist.Models
{
    public class Organization
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Year of Foundation")]
        [YearLowerThanCurrentValidation]
        public int FoundationYear { get; set; }
    }
}