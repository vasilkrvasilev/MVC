using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LibrarySystem.Web.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return comment => new CommentModel
                {
                    Id = comment.Id,
                    Author = comment.Author.UserName,
                    Text = comment.Text,
                    CreatedOn = comment.CreatedOn
                };
            }
        }
    }
}
