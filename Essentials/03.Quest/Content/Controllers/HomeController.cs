using _03.Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Quest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Include("Answers").Include("Answers.Votes").Include("Answers.Votes.VoteTypes")
            var context = new QuestDbEntities();
            var questions = context.Questions.Select(QuestionModel.FromQuestion).ToList();
            return View(questions);
        }

        public ActionResult Search(string searchBox)
        {
            if (searchBox == null)
            {
                searchBox = string.Empty;
            }

            var context = new QuestDbEntities();
            var questions = context.Questions.
                Where(x => x.Text.ToLower().Contains(searchBox.ToLower())).
                Select(QuestionModel.FromQuestion).ToList();
            return View(questions);
        }

        public ActionResult ById(int id)
        {
            var context = new QuestDbEntities();
            var question = context.Questions.
                Where(x => x.Id == id).
                Select(QuestionModel.FromQuestion).FirstOrDefault();
            return View(question);
        }

        public ActionResult Count()
        {
            var context = new QuestDbEntities();
            var count = context.Questions.Count();
            return Content(count.ToString());
        }
    }
}