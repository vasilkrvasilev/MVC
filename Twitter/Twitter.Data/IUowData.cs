namespace Twitter.Data
{
    using System;
    using Twitter.Models;

    public interface IUowData : IDisposable
    {
        IRepository<Message> Messages { get; }

        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
