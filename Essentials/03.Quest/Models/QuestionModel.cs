using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace _03.Quest.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }

        public static Expression<Func<Question, QuestionModel>> FromQuestion
        {
            get
            {
                return question => new QuestionModel
                {
                    Id = question.Id,
                    Text = question.Text,
                    Answers = question.Answers.AsQueryable().Select(AnswerModel.FromAnswer)
                };
            }
        }
    }
}