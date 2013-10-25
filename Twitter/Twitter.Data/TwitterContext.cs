using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Data
{
    public class TwitterContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }
    }
}
