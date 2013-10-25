using Kendo.Mvc.UI;
using LibrarySystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using LibrarySystem.Models;

namespace LibrarySystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var result = this.Data.Categories.All().Select(CategoryModel.FromCategory)
                .ToList().Select(c => new TreeViewItemModel
                {
                    Text = c.Name,
                    Items = c.Books.Select(b => new TreeViewItemModel
                        {
                            Text = b.Title + " by " + b.Author,
                            Url = "/Home/Detail/" + b.Id
                        })
                        .ToList()
                });

            ViewBag.Books = this.Data.Books.All().Select(BookModel.FromBook).ToList();
            return View(result);
        }

        public JsonResult GetCategories()
        {
            var categories = this.Data.Categories.All()
                .Select(CategoryModel.FromCategory).ToList();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(int? categoryBox, string bookBox)
        {
            var result = this.Data.Books.All();
            if (categoryBox != null)
            {
                result = result.Where(x => x.CategoryId == categoryBox);
            }

            if (!string.IsNullOrWhiteSpace(bookBox))
            {
                result = result.Where(x => x.Title.ToLower().Contains(bookBox.ToLower()));
            }

            return View(result.Select(BookModel.FromBook).ToList());
        }

        public ActionResult Detail(int id)
        {
            var book = this.Data.Books.All().Where(x => x.Id == id)
                .Select(BookFullModel.FromBook).FirstOrDefault();

            return View(book);
        }

        [Authorize]
        public ActionResult Cancel()
        {
            return PartialView("_Empty");
        }

        [Authorize]
        public ActionResult Create(int bookId)
        {
            this.Session["bookId"] = bookId;
            return PartialView("_Create");
        }

        [Authorize]
        public ActionResult CreateOk(CommentCreateModel model)
        {
            int bookId = (int)(this.Session["bookId"] ?? 0);
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                //var user = this.Data.Users.Where(u => u.UserName == username).FirstOrDefault();
                var book = this.Data.Books.All().Where(x => x.Id == bookId).FirstOrDefault();
                //if (book == null)
                //{
                //    ModelState.AddModelError("Place", "Ivalid place id!");
                //}

                //if (user == null)
                //{
                //    ModelState.AddModelError("User", "Ivalid user!");
                //}

                Comment comment = new Comment()
                {
                    Text = model.Text,
                    AuthorId = userId,
                    CreatedOn = DateTime.Now,
                };

                book.Comments.Add(comment);
                this.Data.SaveChanges();

                return PartialView("_Success");
            }

            return PartialView("_Create", model);
        }
    }
}