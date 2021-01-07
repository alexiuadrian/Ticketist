using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(3000)]
        public string Summary { get; set; }

        [Display(Name = "Date of Creation")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Reporter")]
        public string Reporter { get; set; }

        [Required]
        [Display(Name = "Name of Project")]
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Ticket Status")]
        public int StatusId { get; set; }
    }
}