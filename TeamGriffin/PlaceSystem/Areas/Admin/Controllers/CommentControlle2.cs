using PlaceSystem.Areas.Admin.Models;
using PlaceSystem.Data;
using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PlaceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/Comment/
        public ActionResult Index()
        {
            var comments = db.Comments.Select(CommentViewModel.FromComment).ToList();
            return View(comments);
        }

        // GET: /Admin/Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentViewModel commentviewmodel = db.Comments.Select(CommentViewModel.FromComment).FirstOrDefault(x => x.Id == id);
            if (commentviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(commentviewmodel);
        }

        // GET: /Admin/Comment/Create
        public ActionResult Create()
        {
            return View();
        }
        /*
        // POST: /Admin/Comment/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceViewModel placeviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.PlaceViewModel.Add(placeviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placeviewmodel);
        }
        */
        // GET: /Admin/Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlaceViewModel placeviewmodel = db.Places.Select(PlaceViewModel.FromPlace).FirstOrDefault(x => x.Id == id);
            Comment commentviewmodel = db.Comments.FirstOrDefault(x => x.Id == id);
            if (commentviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(commentviewmodel);
        }

        // POST: /Admin/Comment/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment commentviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentviewmodel);
        }

        // GET: /Admin/Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentViewModel commentviewmodel = db.Comments.Select(CommentViewModel.FromComment).FirstOrDefault(x => x.Id == id);
            if (commentviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(commentviewmodel);
        }

        // POST: /Admin/Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment commentviewmodel = db.Comments.FirstOrDefault(x => x.Id == id);
            db.Comments.Remove(commentviewmodel);
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
