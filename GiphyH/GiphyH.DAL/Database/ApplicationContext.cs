using GiphyH.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GiphyH.DAL.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Gif> Gifs { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
