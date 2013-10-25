using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models
{
    public class ApplicationUser : User
    {
        private ICollection<Message> messages;

        public ApplicationUser()
        {
            this.messages = new HashSet<Message>();
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
