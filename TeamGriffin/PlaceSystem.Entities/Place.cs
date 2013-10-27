using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceSystem.CustomAttributes;

namespace PlaceSystem.Entities
{
    public class Place
    {
        public Place()
        {
            this.Comments = new HashSet<Comment>();
            this.Pictures = new HashSet<Picture>();
            this.UsersLiking = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage="Name field is required!!!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Name field should be between {1} and {2} characters long!!!")]
        [Display(Name="Place Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required!!!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description field should be between {1} and {2} characters long!!!")]
        [Display(Name = "Place Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "City field is required!!!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "City field should be between {1} and {2} characters long!!!")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address field is required!!!")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Address field should be between {1} and {2} characters long!!!")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Capacity")]
        //[Range(0, Int32.MaxValue, ErrorMessage = "Minimal capacity should be 0!!!")]
        [MinValueAttribute(0, ErrorMessage="Minimal capacity should be 0!!!")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Category field is required!!!")]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<ApplicationUser> UsersLiking { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
