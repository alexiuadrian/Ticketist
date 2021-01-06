using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketist.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            // Afiseaza toate proiectele din baza de date

            return View();
        }

        // GET: Projects/Details/id
        [Route("Projects/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unui proiect (View separat fata de cel de editare)

            return View();
        }

        // GET: Proiect/Edit/id
        [Route("Proiect/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza un proiect (View separat fata de cel de detalii)

            return View();
        }

        // PUT: Projects/Add
        [Route("Projects/Add")]
        public ActionResult Add()
        {
            // Adauga un proiect

            return View();
        }

        // DELETE: Projects/Delete/id
        [Route("Projects/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge un proiect

            return View("Index");
        }
    }
}