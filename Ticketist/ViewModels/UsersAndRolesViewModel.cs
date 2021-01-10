using System.Collections.Generic;
using Ticketist.Models;

namespace Ticketist.ViewModels
{
    public class UsersAndRolesViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}