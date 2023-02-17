using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserPostApp.Models.DB
{
    public class BlogContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UserAppDb.db");
        }
    }
}
