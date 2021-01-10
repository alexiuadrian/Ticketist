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

            var viewModel = new ProjectsViewModel()
            {
                Projects = projects
            };

            if (User.IsInRole(RoleName.CanManageOrganizations) || User.IsInRole(RoleName.CanManageProjects))
            {
                return View("Index", viewModel);
            }

            return View("IndexReadOnly", viewModel);
        }

        // GET: Projects/Details/id
        [Route("Projects/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unui proiect (View separat fata de cel de editare)
            
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

            var project = projects.SingleOrDefault(p => p.Id == Id);
            
            if (project == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole(RoleName.CanManageOrganizations) || User.IsInRole(RoleName.CanManageProjects))
            {
                return View("Details", project);
            }

            return View("DetailsReadOnly", project);
        }

        public ActionResult Save(Project project)
        {
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

            foreach (var organization in _context.Organizations.ToList())
            {
                foreach (var project1 in projects)
                {
                    if (organization.Id == project1.OrganizationId)
                    {
                        organizations.Add(organization);
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectsAndOrganizationsViewModel()
                {
                    Project = project,
                    Organizations = organizations
                };
                return View("ProjectForm", viewModel);
            }

            if (project.Id == 0)
            {
                _context.Projects.Add(project);

                _context.SaveChanges();

                Project lastProject = new Project();

                foreach (var project1 in _context.Projects.ToList())
                {
                    lastProject = project1;
                }

                _context.UserProjects.Add(new UserProjects()
                {
                    UserId = User.Identity.GetUserId(),
                    ProjectId = lastProject.Id
                });

                _context.SaveChanges();
            }
            else
            {
                var projectInDb = _context.Projects.Single(o => o.Id == project.Id);

                projectInDb.Name = project.Name;
                projectInDb.Description = project.Description;
                projectInDb.StartDate = project.StartDate;
                projectInDb.EndDate = project.EndDate;
                projectInDb.OrganizationId = project.OrganizationId;

                _context.SaveChanges();
            }

            return RedirectToAction("Details/" + project.Id, "Projects");
        }

        // GET: Proiect/Edit/id
        [Route("Project/Edit/{Id}")]
        [Authorize(Roles = RoleName.CanManageProjects)]
        public ActionResult Edit(int Id)
        {
            // Editeaza un proiect (View separat fata de cel de detalii)
            
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

            foreach (var organization in _context.Organizations.ToList())
            {
                foreach (var project1 in projects)
                {
                    if (organization.Id == project1.OrganizationId)
                    {
                        organizations.Add(organization);
                    }
                }
            }

            var project = projects.SingleOrDefault(o => o.Id == Id);

            var viewModel = new ProjectsAndOrganizationsViewModel()
            {
                Project = project,
                Organizations = organizations
            };
            
            return View("ProjectForm", viewModel);
        }

        // PUT: Projects/Add
        [Route("Projects/Add")]
        [Authorize(Roles = RoleName.CanManageProjects)]
        public ActionResult Add()
        {
            // Adauga un proiect
            
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

            foreach (var organization in _context.Organizations.ToList())
            {
                foreach (var project1 in projects)
                {
                    if (organization.Id == project1.OrganizationId)
                    {
                        organizations.Add(organization);
                    }
                }
            }

            var viewModel = new ProjectsAndOrganizationsViewModel()
            {
                Project = new Project()
                {
                    StartDate = DateTime.Today
                },
                Organizations = organizations
            };
            
            return View("ProjectForm", viewModel);
        }

        // DELETE: Projects/Delete/id
        [Route("Projects/Delete/{Id}")]
        [Authorize(Roles = RoleName.CanManageProjects)]
        public ActionResult Delete(int Id)
        {
            // Sterge un proiect
            
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
            
            var projectToDelete = projects.SingleOrDefault(o => o.Id == Id);

            if (projectToDelete == null)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();

            var x = _context.UserProjects.SingleOrDefault(uo =>
                uo.UserId == userId && uo.ProjectId == projectToDelete.Id);

            _context.UserProjects.Remove(x);

            _context.Projects.Remove(projectToDelete);

            _context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }
    }
}