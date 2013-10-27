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
using Microsoft.AspNet.Identity;
using System.IO;

namespace PlaceSystem.Areas.Owner.Controllers
{
    [Authorize(Roles = "Owner")]
    public class PlacesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Owner/Places/
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var places = db.Places.Include(p => p.Owner).Where(p => p.OwnerId == userId);
            return View(places.ToList());
        }

        // GET: /Owner/Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: /Owner/Places/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Owner/Places/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Place place)
        {
            string userId = User.Identity.GetUserId();
            place.OwnerId = userId;

            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.OwnerId = new SelectList(db.Users, "Id", "UserName", place.OwnerId);
            return View(place);
        }

        // GET: /Owner/Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "UserName", place.OwnerId);
            return View(place);
        }

        // POST: /Owner/Places/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Place place)
        {
            string userId = User.Identity.GetUserId();
            place.OwnerId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "UserName", place.OwnerId);
            return View(place);
        }

        // GET: /Owner/Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: /Owner/Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Upload(int? id)
        {
            Place place = db.Places.Find(id);
            return View(place);
            // return View();
        }

        public ActionResult UploadPicture(int? id, IEnumerable<HttpPostedFileBase> upload)
        {

            Place place = db.Places.FirstOrDefault(c => c.Id == id);

            if (upload != null)
            {
                foreach (var file in upload)
                {
                    var fileName = place.Name + "_" + Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/img"), fileName);
                    file.SaveAs(physicalPath);

                    Picture pic = new Picture();
                    pic.PlaceId = place.Id;
                    pic.Name = "..\\img\\" + fileName;

                    db.Pictures.Add(pic);
                    db.SaveChanges();
                }
            }


            return Content("");
        }
    }
}
