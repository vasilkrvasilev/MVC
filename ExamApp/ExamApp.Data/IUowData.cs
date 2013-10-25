using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Data
{
    public interface IUowData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
