using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(3000)]
        public string Summary { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public int ReporterId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}