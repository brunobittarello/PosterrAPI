using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PosterrAPI.Entities;

namespace PosterrAPI.Databases
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Follow> Followes { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}