using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            Random rand = new Random();

            Category sampleCategory = new Category { Name = "New" };
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser", Points = 10 };

            for (int i = 0; i < 10; i++)
            {
                Ticket ticket = new Ticket();
                ticket.ScreenShot = "http://laptop.bg/system/images/26207/thumb/toshiba_satellite_l8501v8.jpg";
                ticket.Category = sampleCategory;
                ticket.Title = "Not working";
                ticket.Priority = Priority.Medium;
                ticket.Description = "Someting is wrong";
                ticket.Author = user;

                var commentsCount = rand.Next(0, 10);
                for (int j = 0; j < commentsCount; j++)
                {
                    ticket.Comments.Add(new Comment { Content = "We are working on it", Author = user });
                }

                context.Tickets.Add(ticket);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
