using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem.Models
{
    public class ApplicationUser : User
    {
        public string Email { get; set; }
    }
}
