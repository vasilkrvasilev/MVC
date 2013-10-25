using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Web.Models
{
    public class BookFullModel : BookModel
    {
        public string Category { get; set; }

        public string Isbn { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal? Price { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        public static Expression<Func<Book, BookFullModel>> FromBook
        {
            get
            {
                return book => new BookFullModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category.Name,
                    Isbn = book.Isbn,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Price = book.Price,
                    Comments = book.Comments.AsQueryable().Select(CommentModel.FromComment).ToList()
                };
            }
        }
    }
}