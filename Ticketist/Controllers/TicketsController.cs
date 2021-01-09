using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ticketist.Models;
using Ticketist.ViewModels;

namespace Ticketist.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext _context;

        public TicketsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Tickets
        public ActionResult Index()
        {
            // Afiseaza toate tichetele din baza de date

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
            
            List<Project> projects = new List<Project>();

            foreach (var project in _context.Projects.ToList())
            {
                foreach (var team in teams)
                {
                    if (project.Id == team.ProjectId)
                    {
                        projects.Add(project);
                    }
                }
            }

            List<Ticket> tickets = new List<Ticket>();

            foreach (var ticket in _context.Tickets.ToList())
            {
                foreach (var project in projects)
                {
                    if (ticket.ProjectId == project.Id)
                    {
                        tickets.Add(ticket);
                    }
                }
            }

            var viewModel = new TicketsViewModel()
                {
                    Tickets = tickets,
                    Statuses = _context.Statuses.ToList()
                };
                
            return View("Index", viewModel);
        }

        // GET: Tickets/Details/id
        [Route("Tickets/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unui tichet (View separat fata de cel de editare)

            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == Id);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            List<Comment> comments = new List<Comment>();

            foreach (var comment in _context.Comments.ToList())
            {
                if (comment.TicketId == Id)
                {
                    comments.Add(comment);
                }
            }

            var viewModel = new TicketAndReporterAndProjectAndStatusViewModel()
            {
                Ticket = ticket,
                Projects = _context.Projects.ToList(),
                Statuses = _context.Statuses.ToList(),
                Comments = comments
            };
            
            return View("Details", viewModel);
        }

        // GET: Tickets/Edit/id
        [Route("Tickets/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza un tichet (View separat fata de cel de detalii)

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

            List<Project> projects = new List<Project>();

            foreach (var project in _context.Projects.ToList())
            {
                foreach (var team in teams)
                {
                    if (project.Id == team.ProjectId)
                    {
                        projects.Add(project);
                    }
                }
            }

            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == Id);

            var viewModel = new TicketAndReporterAndProjectAndStatusViewModel()
            {
                Ticket = ticket,
                Projects = projects,
                Statuses = _context.Statuses.ToList()
            };

            return View("TicketsForm", viewModel);
        }

        // PUT: Tickets/Add
        [Route("Tickets/Add")]
        public ActionResult Add()
        {
            // Adauga un tichet

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

            List<Project> projects = new List<Project>();

            foreach (var project in _context.Projects.ToList())
            {
                foreach (var team in teams)
                {
                    if (project.Id == team.ProjectId)
                    {
                        projects.Add(project);
                    }
                }
            }

            var viewModel = new TicketAndReporterAndProjectAndStatusViewModel()
            {
                Ticket = new Ticket()
                {
                    CreationDate = DateTime.Now,
                    Reporter = User.Identity.Name
                },
                Projects = projects,
                Statuses = _context.Statuses.ToList()
            };

            return View("TicketsForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ticket ticket)
        {
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

            List<Project> projects = new List<Project>();

            foreach (var project in _context.Projects.ToList())
            {
                foreach (var team in teams)
                {
                    if (project.Id == team.ProjectId)
                    {
                        projects.Add(project);
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new TicketAndReporterAndProjectAndStatusViewModel()
                {
                    Ticket = ticket,
                    Projects = projects,
                    Statuses = _context.Statuses.ToList()
                };
                return View("TicketsForm", viewModel);
            }

            ticket.Reporter = User.Identity.Name;
            
            if (ticket.Id == 0)
            {
                _context.Tickets.Add(ticket);

                _context.SaveChanges();

                return RedirectToAction("Index", "Tickets");
            }
            else
            {
                var ticketInDb = _context.Tickets.Single(o => o.Id == ticket.Id);

                ticketInDb.Name = ticket.Name;
                ticketInDb.Summary = ticket.Summary;
                ticketInDb.CreationDate = ticket.CreationDate;
                ticketInDb.Reporter = ticket.Reporter;
                ticketInDb.ProjectId = ticket.ProjectId;
                ticketInDb.StatusId = ticket.StatusId;
                
                _context.SaveChanges();

                return RedirectToAction("Details/" + ticket.Id, "Tickets");
            }
        }

        // DELETE: Tickets/Delete/id
        [Route("Tickets/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge un tichet

            var ticket = _context.Tickets.SingleOrDefault(o => o.Id == Id);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            _context.Tickets.Remove(ticket);

            _context.SaveChanges();

            return RedirectToAction("Index", "Tickets");
        }
    }
}