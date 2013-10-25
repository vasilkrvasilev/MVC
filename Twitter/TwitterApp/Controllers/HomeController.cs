using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;

namespace TwitterApp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUowData data)
            : base(data)
        {
        }

        public HomeController()
            : base()
        {
        }

        public ActionResult Index()
        {
            var messages = this.Data.Messages.All().ToList();
            ViewBag.Tags = this.Data.Tags.All().ToList().
                Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(messages);
        }

        [OutputCache(Duration = 900)]
        public ActionResult ByTag(int selectedTag)
        {
            var messages = this.Data.Tags.GetById(selectedTag).Messages;
            ViewBag.Tags = this.Data.Tags.All().ToList().
                Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(messages);
        }

        public ActionResult ByUser()
        {
            var user = this.HttpContext.User.Identity.Name;
            var messages = this.Data.Messages.All().Where(x => x.Author.UserName == user).ToList();
            ViewBag.Tags = this.Data.Tags.All().ToList().
                Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(messages);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult Cancel()
        {
            return PartialView();
        }

        public ActionResult CreateOk(Message model, string tags)
        {
            if (model.Text == model.Title)
            {
                ModelState.AddModelError("Description", "Text and Title should have different values!");
            }

            Message message = new Message()
            {
                Title = model.Title,
                Text = model.Text,
                CreatedOn = DateTime.Now,
                Author = this.Data.Users.All().FirstOrDefault(
                x => x.UserName == this.HttpContext.User.Identity.Name)
            };

            string[] tagNames = tags.Split(',');
            foreach (var item in tagNames)
            {
                var current = this.Data.Tags.All().FirstOrDefault(x => item.ToLower() == x.Name);
                if (current == null)
                {
                    current = new Tag { Name = item.ToLower() };
                }

                message.Tags.Add(current);
            }

            this.Data.Messages.Add(message);
            this.Data.SaveChanges();
            return RedirectToAction("ByUser");
        }
    }
}