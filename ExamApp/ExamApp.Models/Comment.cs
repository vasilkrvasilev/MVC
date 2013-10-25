using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExamApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
