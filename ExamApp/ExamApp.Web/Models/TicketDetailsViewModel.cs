using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ExamApp.Web.Models
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string ScreenShot { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Ticket, TicketDetailsViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketDetailsViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    Priority = ticket.Priority,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    ScreenShot = ticket.ScreenShot,
                    Comments = ticket.Comments.AsQueryable().Select(CommentViewModel.FromComment)
                };
            }
        }
    }
}