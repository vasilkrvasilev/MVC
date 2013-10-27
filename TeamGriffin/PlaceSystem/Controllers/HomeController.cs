using PlaceSystem.Data;
using PlaceSystem.Entities;
using PlaceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaceSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new DataContext();
            var places = context.Places.Select(PlaceModel.FromPlace).ToList();
            var cities = context.Places.Select(x => x.City).Distinct().ToList();
            ViewBag.Cities = cities;
            return View(places);
        }

        public ActionResult Search(string cityBox, Category? categoryBox)
        {
            var context = new DataContext();
            var places = context.Places.Select(PlaceModel.FromPlace).ToList();

            if (string.IsNullOrWhiteSpace(cityBox) && !string.IsNullOrWhiteSpace(categoryBox.ToString()))
            {
                places = context.Places.Where(
                    x => x.Category == categoryBox).
                    Select(PlaceModel.FromPlace).ToList();
            }

            if (string.IsNullOrWhiteSpace(categoryBox.ToString()) && !string.IsNullOrWhiteSpace(cityBox))
            {
                places = context.Places.Where(
                    x => x.City.ToLower() == cityBox.ToLower()).
                    Select(PlaceModel.FromPlace).ToList();
            }

            if (!string.IsNullOrWhiteSpace(categoryBox.ToString()) && !string.IsNullOrWhiteSpace(cityBox))
            {
                places = context.Places.Where(
                    x => x.City.ToLower() == cityBox.ToLower() &&
                    x.Category == categoryBox).
                    Select(PlaceModel.FromPlace).ToList();
            }

            var cities = context.Places.Select(x => x.City).Distinct().ToList();
            ViewBag.Cities = cities;
            return View(places);
        }

        [Authorize]
        public ActionResult ByUser()
        {
            var user = this.HttpContext.User.Identity.Name;
            var context = new DataContext();
            var places = context.Places.Where(
                    x => x.UsersLiking.Any(u => u.UserName == user)).
                    Select(PlaceModel.FromPlace).ToList();

            var cities = context.Places.Select(x => x.City).Distinct().ToList();
            ViewBag.Cities = cities;
            return View(places);
        }

        public ActionResult Detail(int id)
        {
            var context = new DataContext();
            var place = context.Places.Where(x => x.Id == id)
                .Select(PlaceFullModel.FromPlace).FirstOrDefault();

            var cities = context.Places.Select(x => x.City).Distinct().ToList();
            ViewBag.Cities = cities;
            return View(place);
        }

        [Authorize]
        public ActionResult Like(int id)
        {
            var context = new DataContext();
            var place = context.Places.Where(x => x.Id == id).FirstOrDefault();
            var username = this.HttpContext.User.Identity.Name;
            var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
            place.UsersLiking.Add(user);
            context.SaveChanges();
            return RedirectToAction("ByUser");
        }

        [Authorize]
        public ActionResult Dislike(int id)
        {
            var context = new DataContext();
            var place = context.Places.Where(x => x.Id == id).FirstOrDefault();
            var username = this.HttpContext.User.Identity.Name;
            var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
            place.UsersLiking.Remove(user);
            context.SaveChanges();
            return RedirectToAction("ByUser");
        }

        [Authorize]
        public ActionResult Cancel()
        {
            return PartialView("_Empty");
        }

        [Authorize]
        public ActionResult Create(int placeId)
        {
            this.Session["placeId"] = placeId;
            return PartialView("_Create");
        }

        [Authorize]
        public ActionResult CreateOk(CommentModel model)
        {
            int placeId = (int)(this.Session["placeId"] ?? 0);
            if (ModelState.IsValid)
            {
                var context = new DataContext();
                var username = this.HttpContext.User.Identity.Name;
                var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                var place = context.Places.Where(x => x.Id == placeId).FirstOrDefault();
                if (place == null)
                {
                    ModelState.AddModelError("Place", "Ivalid place id!");
                }

                if (user == null)
                {
                    ModelState.AddModelError("User", "Ivalid user!");
                }

                Comment comment = new Comment()
                {
                    Text = model.Text,
                    User = user
                };

                place.Comments.Add(comment);
                context.SaveChanges();

                return PartialView("_Success");
            }

            return PartialView("_Create", model);
        }
    }
}