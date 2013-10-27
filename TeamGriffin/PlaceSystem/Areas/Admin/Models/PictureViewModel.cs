using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Areas.Admin.Models
{
    public class PictureViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public static Expression<Func<Picture, PictureViewModel>> FromPicture
        {
            get
            {
                return pucture => new PictureViewModel
                {
                    Id = pucture.Id,
                    Url = pucture.Name
                };
            }
        }
    }
}