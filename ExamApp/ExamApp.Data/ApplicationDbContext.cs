using ExamApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        //public IDbSet<ApplicationUser> Users { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<Comment> Comments { get; set; }
    }
}
