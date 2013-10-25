using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BookModel> Books { get; set; }

        public static Expression<Func<Category, CategoryModel>> FromCategory
        {
            get
            {
                return category => new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Books = category.Books.AsQueryable().Select(BookModel.FromBook).ToList()
                };
            }
        }
    }
}