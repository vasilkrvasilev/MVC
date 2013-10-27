using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlaceSystem.Entities;
using PlaceSystem.Data;

namespace PlaceSystem.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/Comment/
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Place).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: /Admin/Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /Admin/Comment/Create
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Admin/Comment/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name", comment.PlaceId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: /Admin/Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name", comment.PlaceId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // POST: /Admin/Comment/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name", comment.PlaceId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: /Admin/Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Admin/Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
