using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            var viewModel = new TeamsViewModel()
            {
                Teams = _context.Teams.ToList()
            };

            if (User.IsInRole(RoleName.CanManageOrganizations) || User.IsInRole(RoleName.CanManageProjects) || User.IsInRole(RoleName.CanManageTeams))
            {
                return View("Index", viewModel);
            }

            return View("IndexReadOnly", viewModel);
        }

        public ActionResult Save(Team team)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TeamAndProjectsViewModel()
                {
                    Team = team,
                    Projects = _context.Projects.ToList()
                };
                return View("TeamForm", viewModel);
            }

            if (team.Id == 0)
            {
                _context.Teams.Add(team);
            }
            else
            {
                var teamInDb = _context.Teams.Single(o => o.Id == team.Id);

                teamInDb.Name = team.Name;
                teamInDb.Code = team.Code;
                teamInDb.ProjectId = team.ProjectId;
            }

            _context.SaveChanges();

            return RedirectToAction("Details/" + team.Id, "Teams");
        }

        // GET: Teams/Details/id
        [Route("Teams/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unei echipe (View separat fata de cel de editare)

            var team = _context.Teams.SingleOrDefault(t => t.Id == Id);

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

            var team = _context.Teams.SingleOrDefault(t => t.Id == Id);

            var viewModel = new TeamAndProjectsViewModel()
            {
                Team = team,
                Projects = _context.Projects.ToList()
            };
            
            return View("TeamForm", viewModel);
        }

        // PUT: Teams/Add
        [Route("Teams/Add")]
        [Authorize(Roles = RoleName.CanManageTeams)]
        public ActionResult Add()
        {
            // Adauga o echipa

            var viewModel = new TeamAndProjectsViewModel()
            {
                Team = new Team(),
                Projects = _context.Projects.ToList()
            };
            
            return View("TeamForm", viewModel);
        }

        // DELETE: Teams/Delete/id
        [Route("Teams/Delete/{Id}")]
        [Authorize(Roles = RoleName.CanManageTeams)]
        public ActionResult Delete(int Id)
        {
            // Sterge o echipa
            
            var team = _context.Teams.SingleOrDefault(o => o.Id == Id);

            if (team == null)
            {
                return HttpNotFound();
            }

            _context.Teams.Remove(team);

            _context.SaveChanges();

            return RedirectToAction("Index", "Teams");
        }
    }
}