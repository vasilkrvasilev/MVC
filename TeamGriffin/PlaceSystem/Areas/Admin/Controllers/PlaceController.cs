using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlaceSystem.Data;
using PlaceSystem.Areas.Admin.Models;
using PlaceSystem.Entities;

namespace PlaceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlaceController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/Place/
        public ActionResult Index()
        {
            var places = db.Places.Select(PlaceViewModel.FromPlace).ToList();
            return View(places);
        }

        // GET: /Admin/Place/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceViewModel placeviewmodel = db.Places.Select(PlaceViewModel.FromPlace).FirstOrDefault(x => x.Id == id);
            if (placeviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(placeviewmodel);
        }

        // GET: /Admin/Place/Create
        public ActionResult Create()
        {
            return View();
        }
        /*
        // POST: /Admin/Place/Create
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
        // GET: /Admin/Place/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlaceViewModel placeviewmodel = db.Places.Select(PlaceViewModel.FromPlace).FirstOrDefault(x => x.Id == id);
            Place placeviewmodel = db.Places.FirstOrDefault(x => x.Id == id);
            if (placeviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(placeviewmodel);
        }

        // POST: /Admin/Place/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Place placeviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placeviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placeviewmodel);
        }

        // GET: /Admin/Place/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceViewModel placeviewmodel = db.Places.Select(PlaceViewModel.FromPlace).FirstOrDefault(x => x.Id == id);
            if (placeviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(placeviewmodel);
        }
        
        // POST: /Admin/Place/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place placeviewmodel = db.Places.FirstOrDefault(x => x.Id == id);
            db.Places.Remove(placeviewmodel);
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
