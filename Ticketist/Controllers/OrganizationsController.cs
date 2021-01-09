using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
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
            _context.Dispose(); List<string> hellos = new List<string>();
        }
        
        // GET: Organization
        public ActionResult Index()
        {
            // Afiseaza toate organizatiile din baza de date
            
            var viewModel = new OrganizationsViewModel()
            {
                Organizations = _context.Organizations.ToList()
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

            var organization = _context.Organizations.SingleOrDefault(t => t.Id == Id);

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
            }
            else
            {
                var organizationInDb = _context.Organizations.Single(o => o.Id == organization.Id);

                organizationInDb.Name = organization.Name;
                organizationInDb.Code = organization.Code;
                organizationInDb.Description = organization.Description;
                organizationInDb.FoundationYear = organization.FoundationYear;
            }

            _context.SaveChanges();

            return RedirectToAction("Details/" + organization.Id, "Organizations");
        }
        
        // GET: Organizations/Edit/id
        [Route("Organizations/Edit/{Id}")]
        [Authorize(Roles = RoleName.CanManageOrganizations)]
        public ActionResult Edit(int Id)
        {
            // Editeaza o organizatie (View separat fata de cel de detalii)

            var organization = _context.Organizations.SingleOrDefault(o => o.Id == Id);

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

            var organization = _context.Organizations.SingleOrDefault(o => o.Id == Id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            _context.Organizations.Remove(organization);

            _context.SaveChanges();

            return RedirectToAction("Index", "Organizations");
        }
    }
}