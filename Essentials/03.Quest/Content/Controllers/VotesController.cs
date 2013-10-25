using _03.Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Quest.Controllers
{
    public class VotesController : Controller
    {
        public ActionResult Count()
        {
            var context = new QuestDbEntities();
            var count = context.Votes.Count();
            return Content(count.ToString());
        }
	}
}