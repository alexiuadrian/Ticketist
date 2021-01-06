using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class Status
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}