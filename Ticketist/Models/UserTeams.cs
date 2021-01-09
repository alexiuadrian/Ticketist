using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class UserTeams
    {
        [Required] 
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}