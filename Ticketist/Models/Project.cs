using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Mapping;

namespace Ticketist.Models
{
    public class Project
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