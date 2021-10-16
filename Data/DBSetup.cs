using Brandon_RedditAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Brandon_RedditAPI.Data
{
    public class DBSetup: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Filename = BrandonRedditAPI;");
        }

        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Vote> votes { get; set; }
    }

}
