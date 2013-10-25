using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new MovieDbEntities();
            var movies = context.Movies.Select(MovieModel.FromMovie).ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var context = new MovieDbEntities();
            var movie = context.Movies.Where(x => x.Id == id).Select(MovieFullModel.FromMovie).FirstOrDefault();
            return View(movie);
        }

        public ActionResult Cancel()
        {
            return PartialView("_Empty");
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult CreateOk(MovieFullModel model)
        {
            Movy movie = new Movy()
            {
                Director = model.Director,
                Title = model.MovieTitle,
                Year = model.Year,
                MaleRoleName = model.MaleRoleName,
                MaleRoleAge = model.MaleRoleAge,
                FemaleRoleName = model.FemaleRoleName,
                FemaleRoleAge = model.FemaleRoleAge,
                Studio = model.Studio,
                StudioAddress = model.StudioAddress
            };

            var context = new MovieDbEntities();
            context.Movies.Add(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = new MovieDbEntities();
            var movie = context.Movies.Where(x => x.Id == id).Select(MovieFullModel.FromMovie).FirstOrDefault();
            return PartialView("_Edit", movie);
        }

        public ActionResult EditOk(int id, MovieFullModel model)
        {
            var context = new MovieDbEntities();
            var movie = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            movie.Director = model.Director;
            movie.Title = model.MovieTitle;
            movie.Year = model.Year;
            movie.MaleRoleName = model.MaleRoleName;
            movie.MaleRoleAge = model.MaleRoleAge;
            movie.FemaleRoleName = model.FemaleRoleName;
            movie.FemaleRoleAge = model.FemaleRoleAge;
            movie.Studio = model.Studio;
            movie.StudioAddress = model.StudioAddress;
            context.SaveChanges();
            return RedirectToAction("Detail", new { id = id });
        }

        public ActionResult Delete(int id)
        {
            var context = new MovieDbEntities();
            var movie = context.Movies.Where(x => x.Id == id).Select(MovieModel.FromMovie).FirstOrDefault();
            return PartialView("_Delete", movie);
        }

        public ActionResult DeleteOk(int id)
        {
            var context = new MovieDbEntities();
            var movie = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}