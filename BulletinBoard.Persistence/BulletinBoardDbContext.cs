using BulletinBoard.Application.Interfaces;
using BulletinBoard.Domain;
using BulletinBoard.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Persistence
{
    public class BulletinBoardDbContext : DbContext, IBulletinBoardDbContextcs
    {
        public DbSet<Ad> Ads { get; set; }
        public BulletinBoardDbContext(DbContextOptions<BulletinBoardDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdConfiguration());
            base.OnModelCreating(builder);
        }
        
    }
}
