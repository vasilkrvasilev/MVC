using LibrarySystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Comment> Comments { get; set; }
    }
}
