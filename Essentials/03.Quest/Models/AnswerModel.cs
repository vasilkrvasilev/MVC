using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _03.Quest.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public IEnumerable<VoteModel> Votes { get; set; }

        public static Expression<Func<Answer, AnswerModel>> FromAnswer
        {
            get
            {
                return answer => new AnswerModel
                {
                    Id = answer.Id,
                    Text = answer.Text,
                    QuestionId = answer.QuestionId,
                    Question = answer.Question.Text,
                    Votes = answer.Votes.AsQueryable().Select(VoteModel.FromVote)
                };
            }
        }
    }
}
