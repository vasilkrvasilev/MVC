using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string PlaceName { get; set; }

        public static Expression<Func<Picture, PictureModel>> FromPicture
        {
            get
            {
                return picture => new PictureModel
                {
                    Id = picture.Id,
                    Url = picture.Name,
                    PlaceName = picture.Place.Name,
                   
                };
            }
        }
    }
}