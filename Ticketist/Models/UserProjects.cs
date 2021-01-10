using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class UserProjects
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}