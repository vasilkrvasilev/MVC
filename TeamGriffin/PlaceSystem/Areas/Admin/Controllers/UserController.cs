using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlaceSystem.Areas.Admin.Models;
using PlaceSystem.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PlaceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/User/
        public ActionResult Index()
        {
            var users = db.Users.Select(UserViewModel.FromAppUser).ToList();
            return View(users);
        }

        // GET: /Admin/User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userviewmodel = db.Users.Select(UserViewModel.FromAppUser).FirstOrDefault(x => x.Id == id);
            if (userviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(userviewmodel);
        }
        /*
        // GET: /Admin/User/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Admin/User/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userviewmodel);

            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Users, "Id", "UserName", place.OwnerId);
            return View(place);
        }*/

        // GET: /Admin/User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userviewmodel = db.Users.Where(
                x => x.Id == id).Select(UserViewModel.FromAppUser).FirstOrDefault();
            if (userviewmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userviewmodel.Id);
            ViewBag.ViewRoles = db.Roles.Select(x => x.Name).ToList();
            return View(userviewmodel);
        }

        // POST: /Admin/User/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userviewmodel, string Role)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(x => x.Id == userviewmodel.Id).FirstOrDefault();
                var role = db.Roles.First(r => r.Name == Role);
                //user.Roles.FirstOrDefault().RoleId = role.FirstOrDefault().RoleId;
                user.Roles.Clear();
                user.Roles.Add(new UserRole() { Role = role });

                //var userrole = user.Roles.FirstOrDefault();
                //userrole.Role.Name = role.Role.Name;
                //db.Entry(userviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userviewmodel.Id);
            ViewBag.ViewRoles = db.UserRoles.Select(x => x.Role.Name).ToList();
            return View(userviewmodel);
        }

        // GET: /Admin/User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userviewmodel = db.Users.FirstOrDefault(x => x.Id == id);
            if (userviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(userviewmodel);
        }

        // POST: /Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var userviewmodel = db.Users.FirstOrDefault(x => x.Id == id);
            db.Users.Remove(userviewmodel);
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
