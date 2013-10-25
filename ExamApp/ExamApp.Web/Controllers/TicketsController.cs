using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamApp.Web.Models;
using Microsoft.AspNet.Identity;
using ExamApp.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace ExamApp.Web.Controllers
{
    public class TicketsController : BaseController
    {
        public ActionResult Details(int id)
        {
            var ticket = this.Data.Tickets.All().Where(x => x.Id == id).
                Select(TicketDetailsViewModel.FromTicket).FirstOrDefault();

            return View(ticket);
        }

        [Authorize]
        public ActionResult PostComment(CommentPostModel model)
        {
            if (!ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                var ticket = this.Data.Tickets.All().FirstOrDefault(x => x.Id == model.TicketId);
                var comment = new Comment()
                {
                    AuthorId = userId,
                    Content = model.Content,
                    //TicketId = model.TicketId
                };

                ticket.Comments.Add(comment);
                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { Author = username, Content = model.Content };
                return PartialView("_Comment", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        public ActionResult AddTicket()
        {
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All().ToList(), "Id", "Name");
            return View();
        }

        [Authorize]
        public ActionResult PostTicket(TicketPostModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.Data.Users.All().FirstOrDefault(x => x.Id == userId);
                var ticket = new Ticket()
                {
                    AuthorId = userId,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    Priority = model.Priority,
                    Description = model.Description,
                    ScreenShot = model.ScreenShot
                };

                user.Points += 1;
                this.Data.Tickets.Add(ticket);
                this.Data.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.Data.Tickets.All().
                Select(TicketListViewModel.FromTicket).
                ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Search(int? categorySearch)
        {
            var result = this.Data.Tickets.All();
            if (categorySearch != null)
            {
                result = result.Where(x => x.CategoryId == categorySearch);
            }

            return View(result.Select(TicketListViewModel.FromTicket).ToList());
        }
    }
}