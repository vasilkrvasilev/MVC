using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Models
{
    public class PlaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Category Category { get; set; }
        public IEnumerable<PictureModel> Pictures { get; set; }

        public static Expression<Func<Place, PlaceModel>> FromPlace
        {
            get
            {
                return place => new PlaceModel
                {
                    Id = place.Id,
                    Name = place.Name,
                    City = place.City,
                    Category = place.Category,
                    Pictures = place.Pictures.AsQueryable().Select(PictureModel.FromPicture)
                };
            }
        }
    }
}