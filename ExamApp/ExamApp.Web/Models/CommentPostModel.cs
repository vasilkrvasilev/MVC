using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamApp.Web.Models
{
    public class CommentPostModel
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}