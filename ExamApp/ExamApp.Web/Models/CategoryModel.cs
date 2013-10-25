using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ExamApp.Web.Models
{
    public class CategoryModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryModel>> FromCategory
        {
            get
            {
                return category => new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }
    }
}