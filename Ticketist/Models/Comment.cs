using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        
        [Required] 
        public string User { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}