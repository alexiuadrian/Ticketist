using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class CommentsViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}