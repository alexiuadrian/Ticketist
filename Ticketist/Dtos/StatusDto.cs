using System.ComponentModel.DataAnnotations;

namespace Ticketist.Dtos
{
    public class StatusDto
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}