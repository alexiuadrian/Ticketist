using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Dtos
{
    public class ProjectDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int OrganizationId { get; set; }
    }
}