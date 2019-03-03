using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestQuizz.Models
{
    using Microsoft.EntityFrameworkCore;

    namespace AuthApp.Models
    {
        public class UserContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Quiz> Quizes { get; set; }
            public UserContext(DbContextOptions<UserContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                .HasMany(c => c.Quizes)
                .WithOne(e => e.User);
            }
        }
    }
}
