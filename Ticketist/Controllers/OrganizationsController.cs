using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketist.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            // Afiseaza toate organizatiile din baza de date

            return View();
        }

        // GET: Organizations/Details/id
        [Route("Organizations/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unei organizatii (View separat fata de cel de editare)

            return View();
        }

        // GET: Organizations/Edit/id
        [Route("Organizations/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza o organizatie (View separat fata de cel de detalii)

            return View();
        }

        // PUT: Organizations/Add
        [Route("Organizations/Add")]
        public ActionResult Add()
        {
            // Adauga o organizatie

            return View();
        }

        // DELETE: Organizations/Delete/id
        [Route("Organizations/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge o organizatie

            return View("Index");
        }
    }
}