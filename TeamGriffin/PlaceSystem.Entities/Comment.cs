using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceSystem.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Comment text is required!!!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Comment field should be between {1} and {2} characters long!!!")]
        [Display(Name = "Comment Text")]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
