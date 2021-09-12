using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MessagingContext : DbContext
    {
        public MessagingContext(DbContextOptions<MessagingContext> options): base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Messaging;Trusted_Connection=true");
        //}

        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<UserActivity> UserActivity { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBlockedUserMapping> UserBlockedUserMapping { get; set; }
    }
}
