using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketist.Models;
using Ticketist.ViewModels;

namespace Ticketist.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Projects
        public ActionResult Index()
        {
            // Afiseaza toate proiectele din baza de date

            var viewModel = new ProjectsViewModel()
            {
                Projects = _context.Projects.ToList()
            };
            
            return View(viewModel);
        }

        // GET: Projects/Details/id
        [Route("Projects/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unui proiect (View separat fata de cel de editare)

            return View();
        }

        public ActionResult Save(Project project)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectsAndOrganizationsViewModel()
                {
                    Project = project,
                    Organizations = _context.Organizations.ToList()
                };
                return View("ProjectForm", viewModel);
            }

            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDb = _context.Projects.Single(o => o.Id == project.Id);

                projectInDb.Name = project.Name;
                projectInDb.Description = project.Description;
                projectInDb.StartDate = project.StartDate;
                projectInDb.EndDate = project.EndDate;
                projectInDb.OrganizationId = project.OrganizationId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }

        // GET: Proiect/Edit/id
        [Route("Project/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza un proiect (View separat fata de cel de detalii)

            var project = _context.Projects.SingleOrDefault(o => o.Id == Id);

            var viewModel = new ProjectsAndOrganizationsViewModel()
            {
                Project = project,
                Organizations = _context.Organizations.ToList()
            };
            
            return View("ProjectForm", viewModel);
        }

        // PUT: Projects/Add
        [Route("Projects/Add")]
        public ActionResult Add()
        {
            // Adauga un proiect

            var viewModel = new ProjectsAndOrganizationsViewModel()
            {
                Project = new Project()
                {
                    StartDate = DateTime.Today
                },
                Organizations = _context.Organizations.ToList()
            };
            
            return View("ProjectForm", viewModel);
        }

        // DELETE: Projects/Delete/id
        [Route("Projects/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge un proiect

            var project = _context.Projects.SingleOrDefault(o => o.Id == Id);

            if (project == null)
            {
                return HttpNotFound();
            }

            _context.Projects.Remove(project);

            _context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }
    }
}