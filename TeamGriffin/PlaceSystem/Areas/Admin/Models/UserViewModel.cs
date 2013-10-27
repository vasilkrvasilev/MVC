
using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public int CommentsNumber { get; set; }

        public int FavoriteCount { get; set; }

        public ApplicationUser User { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> FromAppUser
        {
            get
            {
                return User => new UserViewModel
                {
                    Id = User.Id,
                    Username = User.UserName,
                    Role = User.Roles.FirstOrDefault().Role.Name,
                    CommentsNumber = User.Comments.Count,
                    FavoriteCount = User.Favorites.Count,
                };
            }
        }
    }
}