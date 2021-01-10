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
    public class TeamsController : Controller
    {
        private ApplicationDbContext _context;

        public TeamsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Teams
        public ActionResult Index()
        {
            // Afiseaza toate echipele din baza de date

            List<UserTeams> userTeams = new List<UserTeams>();

            foreach (var userTeam in _context.UserTeams.ToList())
            {
                if (userTeam.UserId == User.Identity.GetUserId())
                {
                    userTeams.Add(userTeam);
                }
            }

            List<Team> teams = new List<Team>();

            foreach (var team in _context.Teams.ToList())
            {
                foreach (var userTeam in userTeams)
                {
                    if (userTeam.TeamId == team.Id)
                    {
                        teams.Add(team);
                    }
                }
            }

            var viewModel = new TeamsViewModel()
            {
                Teams = teams
            };

            if (User.IsInRole(RoleName.CanManageOrganizations) || User.IsInRole(RoleName.CanManageProjects) || User.IsInRole(RoleName.CanManageTeams))
            {
                return View("Index", viewModel);
            }

            return View("IndexReadOnly", viewModel);
        }

        public ActionResult Save(Team team)
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

            if (!ModelState.IsValid)
            {
                var viewModel = new TeamAndProjectsViewModel()
                {
                    Team = team,
                    Projects = projects
                };
                return View("TeamForm", viewModel);
            }

            if (team.Id == 0)
            {
                _context.Teams.Add(team);

                _context.SaveChanges();

                Team lastTeam = new Team();

                foreach (var team1 in _context.Teams.ToList())
                {
                    lastTeam = team1;
                }

                _context.UserTeams.Add(new UserTeams()
                {
                    UserId = User.Identity.GetUserId(),
                    TeamId = lastTeam.Id
                });

                _context.SaveChanges();
            }
            else
            {
                var teamInDb = _context.Teams.Single(o => o.Id == team.Id);

                teamInDb.Name = team.Name;
                teamInDb.Code = team.Code;
                teamInDb.ProjectId = team.ProjectId;

                _context.SaveChanges();
            }

            return RedirectToAction("Details/" + team.Id, "Teams");
        }

        // GET: Teams/Details/id
        [Route("Teams/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unei echipe (View separat fata de cel de editare)

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

            var team = teams.SingleOrDefault(t => t.Id == Id);

            if (team == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole(RoleName.CanManageOrganizations) || User.IsInRole(RoleName.CanManageProjects) || User.IsInRole(RoleName.CanManageTeams))
            {
                return View("Details", team);
            }

            return View("DetailsReadOnly", team);
        }

        // GET: Teams/Edit/id
        [Route("Teams/Edit/{Id}")]
        [Authorize(Roles = RoleName.CanManageTeams)]
        public ActionResult Edit(int Id)
        {
            // Editeaza o echipa (View separat fata de cel de detalii)

            List<UserTeams> userTeams = new List<UserTeams>();

            foreach (var userTeam in _context.UserTeams.ToList())
            {
                if (userTeam.UserId == User.Identity.GetUserId())
                {
                    userTeams.Add(userTeam);
                }
            }

            List<Team> teams = new List<Team>();

            foreach (var team1 in _context.Teams.ToList())
            {
                foreach (var userTeam in userTeams)
                {
                    if (userTeam.TeamId == team1.Id)
                    {
                        teams.Add(team1);
                    }
                }
            }

            List<Project> projects = new List<Project>();

            foreach (var project in _context.Projects.ToList())
            {
                foreach (var team1 in teams)
                {
                    if (project.Id == team1.ProjectId)
                    {
                        projects.Add(project);
                    }
                }
            }

            // var team = _context.Teams.SingleOrDefault(t => t.Id == Id);

            var team = teams.SingleOrDefault(t => t.Id == Id);

            var viewModel = new TeamAndProjectsViewModel()
            {
                Team = team,
                Projects = projects
            };
            
            return View("TeamForm", viewModel);
        }

        // PUT: Teams/Add
        [Route("Teams/Add")]
        [Authorize(Roles = RoleName.CanManageTeams)]
        public ActionResult Add()
        {
            // Adauga o echipa

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

            var viewModel = new TeamAndProjectsViewModel()
            {
                Team = new Team(),
                Projects = projects
            };
            
            return View("TeamForm", viewModel);
        }

        // DELETE: Teams/Delete/id
        [Route("Teams/Delete/{Id}")]
        [Authorize(Roles = RoleName.CanManageTeams)]
        public ActionResult Delete(int Id)
        {
            // Sterge o echipa

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

            var team = teams.SingleOrDefault(o => o.Id == Id);

            if (team == null)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();

            var x = _context.UserTeams.SingleOrDefault(uo =>
                uo.UserId == userId && uo.TeamId == team.Id);

            _context.UserTeams.Remove(x);

            _context.Teams.Remove(team);

            _context.SaveChanges();

            return RedirectToAction("Index", "Teams");
        }
    }
}