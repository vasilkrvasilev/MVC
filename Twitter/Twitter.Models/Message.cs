using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Message
    {
        private ICollection<Tag> tags;

        public Message()
        {
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage="To create new message you should enter title")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Title should be between {2} and {1} symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage = "To create new message you should enter text")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Text should be between {2} and {1} symbols")]
        public string Text { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
