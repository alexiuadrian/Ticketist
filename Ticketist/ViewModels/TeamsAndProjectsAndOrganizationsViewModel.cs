using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class TeamsAndProjectsAndOrganizationsViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public int nrOfTickets { get; set; }
    }
}