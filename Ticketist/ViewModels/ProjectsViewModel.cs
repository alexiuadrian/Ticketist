using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}