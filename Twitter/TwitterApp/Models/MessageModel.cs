//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Web;
//using Twitter.Models;

//namespace TwitterApp.Models
//{
//    public class MessageModel
//    {
//        public int Id { get; set; }
//        public string Director { get; set; }
//        public string Text { get; set; }    
//        public DateTime CreatedOn { get; set; }
//        public int FemaleRoleAge { get; set; }
//        public string StudioAddress { get; set; }

//        public static Expression<Func<Message, MessageModel>> FromMessage
//        {
//            get
//            {
//                return message => new MessageModel
//                {
//                    Id = message.Id,
//                    Director = message.Title,
//                    Text = message.Text,
//                    CreatedOn = message.CreatedOn,
//                    Author = message.Author.UserName,
//                    AuthorId = message.Author.Id,
//                    FemaleRoleName = movie.FemaleRoleName,
//                    FemaleRoleAge = movie.FemaleRoleAge,
//                    Studio = movie.Studio,
//                    StudioAddress = movie.StudioAddress
//                };
//            }
//        }
//    }
//}