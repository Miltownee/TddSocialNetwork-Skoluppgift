using Microsoft.EntityFrameworkCore;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Data
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext()
        {
        }

        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}