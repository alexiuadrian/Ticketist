using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Ticketist.Models
{
    public class Organization
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