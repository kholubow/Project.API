using Microsoft.EntityFrameworkCore;
using Project.API.Models;

namespace Project.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Instance> Instances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasOne(u => u.Sender)
                                     .WithMany(m => m.MessagesSent)
                                     .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>().HasOne(u => u.Recipient)
                                     .WithMany(m => m.MessagesReceived)
                                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
