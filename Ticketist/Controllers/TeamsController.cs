using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketist.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {
            // Afiseaza toate echipele din baza de date

            return View();
        }

        // GET: Teams/Details/id
        [Route("Teams/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unei echipe (View separat fata de cel de editare)

            return View();
        }

        // GET: Teams/Edit/id
        [Route("Teams/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza o echipa (View separat fata de cel de detalii)

            return View();
        }

        // PUT: Teams/Add
        [Route("Teams/Add")]
        public ActionResult Add()
        {
            // Adauga o echipa

            return View();
        }

        // DELETE: Teams/Delete/id
        [Route("Teams/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge o echipa

            return View("Index");
        }
    }
}