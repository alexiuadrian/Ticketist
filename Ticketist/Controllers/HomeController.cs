using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ticketist.Models;
using Ticketist.ViewModels;

namespace Ticketist.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageOrganizations))
            {
                return View("IndexAdmin");
            }

            if (User.IsInRole(RoleName.CanManageTickets) || User.IsInRole(RoleName.CanManageProjects) ||
                User.IsInRole(RoleName.CanManageTeams))
            {
                List<Team> teams = new List<Team>();

                foreach (var userTeam in _context.UserTeams.ToList())
                {
                    foreach (var team1 in _context.Teams.ToList())
                    {
                        if (userTeam.UserId == User.Identity.GetUserId() && team1.Id == userTeam.TeamId)
                        {
                            teams.Add(team1);
                        }
                    }
                }

                List<Project> projects = new List<Project>();

                foreach (var userProject in _context.UserProjects.ToList())
                {
                    foreach (var project1 in _context.Projects.ToList())
                    {
                        if (userProject.UserId == User.Identity.GetUserId() && project1.Id == userProject.ProjectId)
                        {
                            projects.Add(project1);
                        }
                    }
                }

                List<Organization> organizations = new List<Organization>();

                foreach (var userOrganization in _context.UserOrganizations.ToList())
                {
                    foreach (var organization1 in _context.Organizations.ToList())
                    {
                        if (userOrganization.UserId == User.Identity.GetUserId() && organization1.Id == userOrganization.OrganizationId)
                        {
                            organizations.Add(organization1);
                        }
                    }
                }

                int nrOfTickets = 0;
                
                foreach (var ticket in _context.Tickets.ToList())
                {
                    if (ticket.Reporter.Equals(User.Identity.GetUserName()))
                    {
                        nrOfTickets++;
                    }
                }

                var viewModel = new TeamsAndProjectsAndOrganizationsViewModel()
                {
                    Teams = teams,
                    Organizations = organizations,
                    Projects = projects,
                    nrOfTickets = nrOfTickets
                };
                
                return View("IndexLoggedIn", viewModel);
            }
            
            return View();
        }
    }
}