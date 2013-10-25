using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ExamApp.Web.Models
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public string Author { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Content = comment.Content,
                    Author = comment.Author.UserName
                };
            }
        }
    }
}