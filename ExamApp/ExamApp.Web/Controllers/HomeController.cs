using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamApp.Web.Models;

namespace ExamApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var tickets = this.Data.Tickets.All().OrderByDescending(x => x.Comments.Count).
                    Take(6).Select(TicketHomeViewModel.FromTicket).ToList();

                this.HttpContext.Cache.Add("HomePageTickets", tickets.ToList(), null, 
                    DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]);
        }
    }
}