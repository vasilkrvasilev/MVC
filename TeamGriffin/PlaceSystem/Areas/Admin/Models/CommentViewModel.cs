using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Areas.Admin.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment text is required!!!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Comment field should be between {1} and {2} characters long!!!")]
        [Display(Name = "Comment Text")]
        public string Text { get; set; }
        public string User { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    User = comment.User.UserName
                };
            }
        }
    }
}