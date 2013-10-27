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
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace PlaceSystem.Areas.Admin.Controllers
{
    public class PicturesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/Pictures/
        public ActionResult Index()
        {
            var pictures = db.Pictures.Include(p => p.Place);
            return View(pictures.ToList());
        }

        // GET: /Admin/Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        public ActionResult RowTemplate()
        {
            return View();
        }

        private IQueryable<Picture> GetPictures()
        {
            var pictures = db.Pictures;
            return pictures;
        }

        public ActionResult RowTemplate_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetPictures().ToDataSourceResult(request));
        }

        // GET: /Admin/Pictures/Create
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name");
            return View();
        }

        // POST: /Admin/Pictures/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name", picture.PlaceId);
            return View(picture);
        }

        // GET: /Admin/Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name", picture.PlaceId);
            return View(picture);
        }

        // POST: /Admin/Pictures/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Name", picture.PlaceId);
            return View(picture);
        }

        // GET: /Admin/Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: /Admin/Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
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
