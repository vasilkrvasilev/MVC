using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Web.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Book, BookModel>> FromBook
        {
            get
            {
                return book => new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author
                };
            }
        }
    }
}