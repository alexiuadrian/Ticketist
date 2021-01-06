using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Dtos
{
    public class CommentDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int TicketId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}