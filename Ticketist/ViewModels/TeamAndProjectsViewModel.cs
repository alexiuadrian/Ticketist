using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class TeamAndProjectsViewModel
    {
        public Team Team { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}