using BulletinBoard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.Persistence.EntityTypeConfigurations
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(ad => ad.Id);
            builder.HasIndex(ad => ad.Id).IsUnique();
            builder.Property(ad => ad.Description).HasMaxLength(500);
            
        }
    }
}
