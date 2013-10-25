using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExamApp.Models
{
    public class Ticket
    {
        private ICollection<Comment> comments;

        public Ticket()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [ShouldNotContainBug]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [RegularExpression(@"^(https?://)?[\w\-\._]+\.[a-zA-Z]{2,6}$")]
        public string ScreenShot { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
