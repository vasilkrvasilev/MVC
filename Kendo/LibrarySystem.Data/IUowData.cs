using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public interface IUowData
    {
        IRepository<Category> Categories { get; }

        IRepository<Book> Books { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
