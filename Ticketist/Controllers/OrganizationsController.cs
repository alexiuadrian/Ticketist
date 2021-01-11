using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ticketist.Models;
using Ticketist.ViewModels;

namespace Ticketist.Controllers
{
    public class OrganizationsController : Controller
    {
        private ApplicationDbContext _context;

        public OrganizationsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: Organization
        public ActionResult Index()
        {
            // Afiseaza toate organizatiile din baza de date

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

            var viewModel = new OrganizationsViewModel()
            {
                Organizations = organizations
            };

            if (User.IsInRole(RoleName.CanManageOrganizations))
            {
                return View("Index", viewModel);
            }

            return View("IndexReadOnly", viewModel);

        }

        [Route("Organizations/Search")]
        public ActionResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        public ActionResult SearchThis(string searchString)
        {
            return RedirectToAction("/" + Int32.Parse(searchString), "Organizations");
        }

        [Route("Organizations/{year:regex(\\d{4})}")]
        public ActionResult Index(int year)
        {
            // Afiseaza toate organizatiile din baza de date

            List <Organization> organizations = new List<Organization>();

            foreach (var userOrganization in _context.UserOrganizations.ToList())
            {
                foreach (var organization1 in _context.Organizations.ToList())
                {
                    if (userOrganization.UserId == User.Identity.GetUserId()
                        && organization1.Id == userOrganization.OrganizationId
                        && organization1.FoundationYear == year)
                    {
                        organizations.Add(organization1);
                    }
                }
            }

            var viewModel = new OrganizationsViewModel()
            {
                Organizations = organizations
            };

            if (User.IsInRole(RoleName.CanManageOrganizations))
            {
                return View("Index", viewModel);
            }

            return View("IndexReadOnly", viewModel);

        }

        // GET: Organizations/Details/id
        [Route("Organizations/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unei organizatii (View separat fata de cel de editare)

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

            var organization = organizations.SingleOrDefault(t => t.Id == Id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole(RoleName.CanManageOrganizations))
            {
                return View("Details", organization);
            }
            
            return View("DetailsReadOnly", organization);

        }

        public ActionResult Save(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View("OrganizationForm", organization);
            }

            if (organization.Id == 0)
            {
                _context.Organizations.Add(organization);

                _context.SaveChanges();

                Organization lastOrganization = new Organization();

                foreach (var organization1 in _context.Organizations.ToList())
                {
                    lastOrganization = organization1;
                }

                _context.UserOrganizations.Add(new UserOrganizations()
                {
                    UserId = User.Identity.GetUserId(),
                    OrganizationId = lastOrganization.Id
                });

                _context.SaveChanges();
            }
            else
            {
                var organizationInDb = _context.Organizations.Single(o => o.Id == organization.Id);

                organizationInDb.Name = organization.Name;
                organizationInDb.Code = organization.Code;
                organizationInDb.Description = organization.Description;
                organizationInDb.FoundationYear = organization.FoundationYear;

                _context.SaveChanges();
            }

            return RedirectToAction("Details/" + organization.Id, "Organizations");
        }
        
        // GET: Organizations/Edit/id
        [Route("Organizations/Edit/{Id}")]
        [Authorize(Roles = RoleName.CanManageOrganizations)]
        public ActionResult Edit(int Id)
        {
            // Editeaza o organizatie (View separat fata de cel de detalii)

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

            var organization = organizations.SingleOrDefault(o => o.Id == Id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            return View("OrganizationForm", organization);
        }

        // PUT: Organizations/Add
        [Route("Organizations/Add")]
        [Authorize(Roles = RoleName.CanManageOrganizations)]
        public ActionResult Add()
        {
            // Adauga o organizatie

            var organization = new Organization()
            {
                FoundationYear = DateTime.Today.Year
            };
            
            return View("OrganizationForm", organization);
        }

        // DELETE: Organizations/Delete/id
        [Route("Organizations/Delete/{Id}")]
        [Authorize(Roles = RoleName.CanManageOrganizations)]
        public ActionResult Delete(int Id)
        {
            // Sterge o organizatie

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

            var organization = organizations.SingleOrDefault(o => o.Id == Id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();

            var org = _context.UserOrganizations.SingleOrDefault(uo =>
                uo.UserId == userId && uo.OrganizationId == organization.Id);

            _context.UserOrganizations.Remove(org);

            _context.SaveChanges();

            _context.Organizations.Remove(organization);

            _context.SaveChanges();

            return RedirectToAction("Index", "Organizations");
        }
    }
}