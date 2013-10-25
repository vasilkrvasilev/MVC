using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _03.Quest.Models
{
    public class VoteModel
    {
        public string Type { get; set; }

        public static Expression<Func<Vote, VoteModel>> FromVote
        {
            get
            {
                return vote => new VoteModel
                {
                    Type = vote.VoteType.Type
                };
            }
        }
    }
}
