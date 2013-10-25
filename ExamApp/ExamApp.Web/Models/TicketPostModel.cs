using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamApp.Web.Models
{
    public class TicketPostModel
    {
        [Required]
        [ShouldNotContainBug]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [RegularExpression(@"^(https?://)?[\w\-\._]+\.[a-zA-Z]{2,6}$")]
        public string ScreenShot { get; set; }
    }
}