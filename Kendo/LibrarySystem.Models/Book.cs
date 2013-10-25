using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibrarySystem.Models
{
    public class Book
    {
        private ICollection<Comment> comments;

        public Book()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Isbn { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal? Price { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
