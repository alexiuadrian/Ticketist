using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class TicketAndReporterAndProjectAndStatusViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}