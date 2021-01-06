using System.ComponentModel.DataAnnotations;

namespace Ticketist.Dtos
{
    public class TeamDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        public int ProjectId { get; set; }
    }
}