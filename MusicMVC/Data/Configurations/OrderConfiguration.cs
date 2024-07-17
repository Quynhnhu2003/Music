using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicMVC.Data.Entities;

namespace MusicMVC.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.UserId)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(o => o.UserId);

            builder.Property(o => o.Note)
                .HasMaxLength(1000);

            builder.Property(o => o.Amount)
                .HasPrecision(18, 6);
        }
    }
}
