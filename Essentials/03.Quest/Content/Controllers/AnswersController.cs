using _03.Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Quest.Controllers
{
    public class AnswersController : Controller
    {
        public ActionResult Index(int id)
        {
            var context = new QuestDbEntities();
            var answer = context.Answers.
                Where(x => x.Id == id).
                Select(AnswerModel.FromAnswer).FirstOrDefault();
            return View(answer);
        }

        public ActionResult VoteYes(int id)
        {
            var context = new QuestDbEntities();
            var answer = context.Answers.FirstOrDefault(x => x.Id == id);
            if (answer != null)
            {
                var vote = new Vote() { TypeId = 1, AnswerId = id };
                answer.Votes.Add(vote);
                context.SaveChanges();
            }

            return RedirectToAction("ById", "Home", new { id = answer.QuestionId });
        }

        public ActionResult VoteNo(int id)
        {
            var context = new QuestDbEntities();
            var answer = context.Answers.FirstOrDefault(x => x.Id == id);
            if (answer != null)
            {
                var vote = new Vote() { TypeId = 2, AnswerId = id };
                answer.Votes.Add(vote);
                context.SaveChanges();
            }

            return RedirectToAction("ById", "Home", new { id = answer.QuestionId });
        }

        public ActionResult Count()
        {
            var context = new QuestDbEntities();
            var count = context.Answers.Count();
            return Content(count.ToString());
        }
	}
}