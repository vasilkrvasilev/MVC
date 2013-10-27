using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Models
{
    public class PlaceFullModel : PlaceModel
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public IEnumerable<UserModel> UserLikers { get; set; }

        public static Expression<Func<Place, PlaceFullModel>> FromPlace
        {
            get
            {
                return place => new PlaceFullModel
                {
                    Id = place.Id,
                    Name = place.Name,
                    City = place.City,
                    Category = place.Category,
                    Pictures = place.Pictures.AsQueryable().Select(PictureModel.FromPicture),
                    Description = place.Description,
                    Address = place.Address,
                    Capacity = place.Capacity,
                    Comments = place.Comments.AsQueryable().Select(CommentModel.FromComment),
                    UserLikers = place.UsersLiking.AsQueryable().Select(UserModel.FromAppUser)
                };
            }
        }
    }
}