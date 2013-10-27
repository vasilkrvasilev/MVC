using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceSystem.Entities
{
    public class ApplicationUser : User
    {
        public ApplicationUser()
        {
            //this.OwnPlaces = new HashSet<Place>();
            this.Favorites = new HashSet<Place>();
            this.Comments = new HashSet<Comment>();
        }

        
        //public virtual ICollection<Place> OwnPlaces { get; set; }
                
        public virtual ICollection<Place> Favorites { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
