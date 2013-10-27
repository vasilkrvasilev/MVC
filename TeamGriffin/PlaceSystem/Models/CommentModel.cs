using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PlaceSystem.Models
{
    public class CommentModel
    {
        [Required(ErrorMessage = "Comment text is required!!!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Comment field should be between {1} and {2} characters long!!!")]
        [Display(Name = "Comment Text")]
        public string Text { get; set; }
        public string User { get; set; }

        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return comment => new CommentModel
                {
                    Text = comment.Text,
                    User = comment.User.UserName
                };
            }
        }
    }
}
