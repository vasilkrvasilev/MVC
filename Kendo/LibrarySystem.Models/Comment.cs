using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibrarySystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
