using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketist.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {
            // Afiseaza toate tichetele din baza de date
            
            return View();
        }

        // GET: Tickets/Details/id
        [Route("Tickets/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            // Vezi detaliile unui tichet (View separat fata de cel de editare)
            
            return View("Details");
        }

        // GET: Tickets/Edit/id
        [Route("Tickets/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza un tichet (View separat fata de cel de detalii)

            return View("TicketsForm");
        }

        // PUT: Tickets/Add
        [Route("Tickets/Add")]
        public ActionResult Add()
        {
            // Adauga un tichet

            return View("TicketsForm");
        }
        
        // DELETE: Tickets/Delete/id
        [Route("Tickets/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge un tichet

            return View("Index");
        }
    }
}