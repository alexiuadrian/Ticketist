namespace Ticketist.ViewModels
{
    public class RolesBooleanViewModel
    {
        public string Id { get; set; }
        public bool CanManageOrganizations { get; set; }
        public bool CanManageProjects { get; set; }
        public bool CanManageTeams { get; set; }
        public bool CanManageTickets { get; set; }
    }
}