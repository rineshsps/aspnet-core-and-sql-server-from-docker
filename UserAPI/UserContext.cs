using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options)
             : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"persistsecurityinfo=True;server=localhost;user id=root;password=password;database=dataexport;allowuservariables=True");
            }
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Uncle",
            }, new User
            {
                Id = 2,
                Name = "Jan"
            });
        }
    }
}
