using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ExamApp.Web.Models
{
    public class TicketHomeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public int Comments { get; set; }

        public static Expression<Func<Ticket, TicketHomeViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketHomeViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Comments = ticket.Comments.Count
                };
            }
        }
    }
}