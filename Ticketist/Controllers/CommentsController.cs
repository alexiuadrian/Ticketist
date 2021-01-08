using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketist.Models;

namespace Ticketist.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;

        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Comments/Edit/id
        [Route("Comments/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            // Editeaza un comentariu (View separat fata de cel de detalii)

            var comment = _context.Comments.SingleOrDefault(t => t.Id == Id);

            return View("CommentForm", comment);
        }

        // PUT: Comments/Add/TicketId
        public ActionResult Add(int TicketId)
        {
            // Adauga un comentariu pentru un anumit tichet

            var comment = new Comment()
            {
                CreationDate = DateTime.Now,
                User = User.Identity.Name,
                TicketId = TicketId
            };

            return View("CommentForm", comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View("CommentForm", comment);
            }

            comment.User = User.Identity.Name;
            
            if (comment.Id == 0)
            {
                _context.Comments.Add(comment);

                _context.SaveChanges();

                return RedirectToAction("Details/" + comment.TicketId, "Tickets");
            }
            else
            {
                var commentInDb = _context.Comments.Single(o => o.Id == comment.Id);

                commentInDb.Description = comment.Description;
                commentInDb.TicketId = comment.TicketId;
                commentInDb.User = comment.User;
                
                _context.SaveChanges();

                return RedirectToAction("Details/" + comment.TicketId, "Tickets");
            }
        }
        
        // DELETE: Comments/Delete/id
        [Route("Comments/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            // Sterge un comentariu

            var comment = _context.Comments.SingleOrDefault(o => o.Id == Id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            _context.Comments.Remove(comment);

            _context.SaveChanges();

            return RedirectToAction("Details/" + comment.TicketId, "Tickets");
        }
    }
}