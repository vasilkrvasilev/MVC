using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceSystem.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Picture field is required!!!")]
        //[RegularExpression(@"^.*\.(jpg|JPG|gif|GIF|png|PNG)$", ErrorMessage="File should be with valid image extension!!!")]
        [Display(Name = "Picture Url")]
        public string Name { get; set; }

        public int PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }
    }
}
