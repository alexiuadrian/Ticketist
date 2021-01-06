using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketist.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments/Edit/id
        [Route("Comments/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza un comentariu (View separat fata de cel de detalii)

            return View();
        }

        // PUT: Comments/Add/TicketId
        [Route("Comments/Add/{TicketId}")]
        public ActionResult Add(int TicketId)
        {
            // Adauga un comentariu pentru un anumit tichet

            return View();
        }

        // DELETE: Comments/Delete/id
        [Route("Comments/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge un comentariu

            return View("Index");
        }
    }
}