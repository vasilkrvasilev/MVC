using _03.Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Quest.Areas.Admin.Controllers
{
    public class AdminQuestionsController : Controller
    {
        public ActionResult Index()
        {
            var context = new QuestDbEntities();
            var questions = context.Questions.Select(QuestionModel.FromQuestion).ToList();
            return View(questions);
        }

        public ActionResult Create(string createQuestionBox, int? id)
        {
            var context = new QuestDbEntities();
            Question question;
            if (!string.IsNullOrWhiteSpace(createQuestionBox))
            {
                question = new Question()
                {
                    Text = createQuestionBox
                };

                context.Questions.Add(question);
                context.SaveChanges();
            }
            else if (id != null)
            {
                question = context.Questions.
                    Where(x => x.Id == id).FirstOrDefault();
            }
            else
            {
                //ViewBag.Message = "You cannot create empty question";
                return RedirectToAction("Index", "AdminQuestions");
            }

            var model = new QuestionModel
            {
                Id = question.Id,
                Text = question.Text,
                Answers = question.Answers.AsQueryable().Select(AnswerModel.FromAnswer)
            };

            return View(model);
        }
	}
}