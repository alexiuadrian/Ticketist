using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class TicketsViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
    }
}