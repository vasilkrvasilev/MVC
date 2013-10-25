using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieApp.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public int Year { get; set; }
        public string Studio { get; set; }

        public static Expression<Func<Movy, MovieModel>> FromMovie
        {
            get
            {
                return movie => new MovieModel
                {
                    Id = movie.Id,
                    MovieTitle = movie.Title,
                    Year = movie.Year,
                    Studio = movie.Studio
                };
            }
        }
    }
}