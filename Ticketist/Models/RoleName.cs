using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class RoleName
    {
        [Display(Name = "Admin")]
        public const string CanManageOrganizations = "CanManageOrganizations";
        
        [Display(Name = "Project Manager")]
        public const string CanManageProjects = "CanManageProjects";

        [Display(Name = "Supervisor")]
        public const string CanManageTeams = "CanManageTeams";

        [Display(Name = "User")]
        public const string CanManageTickets = "CanManageTickets";
    }
}