using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieApp.Models
{
    public class MovieFullModel : MovieModel
    {
        public string Director { get; set; }
        public string MaleRoleName { get; set; }
        public int MaleRoleAge { get; set; }
        public string FemaleRoleName { get; set; }
        public int FemaleRoleAge { get; set; }
        public string StudioAddress { get; set; }

        public static Expression<Func<Movy, MovieFullModel>> FromMovie
        {
            get
            {
                return movie => new MovieFullModel
                {
                    Id = movie.Id,
                    Director = movie.Director,
                    MovieTitle = movie.Title,
                    Year = movie.Year,
                    MaleRoleName = movie.MaleRoleName,
                    MaleRoleAge = movie.MaleRoleAge,
                    FemaleRoleName = movie.FemaleRoleName,
                    FemaleRoleAge = movie.FemaleRoleAge,
                    Studio = movie.Studio,
                    StudioAddress = movie.StudioAddress
                };
            }
        }
    }
}