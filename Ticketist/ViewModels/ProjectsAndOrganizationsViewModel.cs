using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class ProjectsAndOrganizationsViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
    }
}