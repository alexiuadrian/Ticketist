using System.ComponentModel.DataAnnotations;

namespace Ticketist.Dtos
{
    public class OrganizationDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        public string Description { get; set; }

        public int FoundationYear { get; set; }
    }
}