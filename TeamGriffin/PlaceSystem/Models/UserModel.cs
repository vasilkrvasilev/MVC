using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PlaceSystem.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public static Expression<Func<ApplicationUser, UserModel>> FromAppUser
        {
            get
            {
                return user => new UserModel
                {
                    Username = user.UserName
                };
            }
        }
    }
}