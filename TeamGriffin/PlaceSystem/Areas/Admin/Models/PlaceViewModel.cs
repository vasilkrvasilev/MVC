using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Areas.Admin.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Category Category { get; set; }
        public IEnumerable<PictureViewModel> Pictures { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public IEnumerable<UserViewModel> UserLikers { get; set; }

        public string OwnerId { get; set; }
        public string Owner { get; set; }

        public static Expression<Func<Place, PlaceViewModel>> FromPlace
        {
            get
            {
                return place => new PlaceViewModel
                {
                    Id = place.Id,
                    Name = place.Name,
                    City = place.City,
                    Category = place.Category,
                    Pictures = place.Pictures.AsQueryable().Select(PictureViewModel.FromPicture),
                    Description = place.Description,
                    Address = place.Address,
                    Capacity = place.Capacity,
                    Comments = place.Comments.AsQueryable().Select(CommentViewModel.FromComment),
                    UserLikers = place.UsersLiking.AsQueryable().Select(UserViewModel.FromAppUser),
                    OwnerId = place.OwnerId,
                    Owner = place.Owner.UserName,
                };
            }
        }
    }
}