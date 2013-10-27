using Microsoft.AspNet.Identity.EntityFramework;
using PlaceSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PlaceSystem.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Place> Places { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                .HasMany(p => p.UsersLiking)
                .WithMany(p => p.Favorites)
                .Map(a => a.ToTable("Favorites")
                .MapLeftKey("PlaceId")
                .MapRightKey("UserId"));

            base.OnModelCreating(modelBuilder);
        }

        //public System.Data.Entity.DbSet<PlaceSystem.Models.PlaceViewModel> PlaceViewModel { get; set; }
    }
}
