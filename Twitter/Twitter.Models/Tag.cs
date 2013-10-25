using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Twitter.Models
{
    public class Tag
    {
        private ICollection<Message> messages;

        public Tag()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [Display(Name = "Tag")]
        public string Name { get; set; }
        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
