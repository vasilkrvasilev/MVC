using _03.Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Quest.Areas.Admin.Controllers
{
    public class AdminAnswersController : Controller
    {
        public ActionResult Create(string createAnswerBox, int id)
        {
            if (string.IsNullOrWhiteSpace(createAnswerBox))
            {
                //ViewBag.Message = "You cannot create empty question";
                return RedirectToAction("Create", "AdminQuestions", new { id = id });
            }

            var answer = new Answer()
            {
                Text = createAnswerBox
            };

            var context = new QuestDbEntities();
            var question = context.Questions.FirstOrDefault(x => x.Id == id);
            question.Answers.Add(answer);
            context.SaveChanges();
            return RedirectToAction("Create", "AdminQuestions", new { id = answer.QuestionId });
        }
	}
}