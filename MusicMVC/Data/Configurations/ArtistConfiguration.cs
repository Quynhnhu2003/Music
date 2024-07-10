using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicMVC.Commons;
using MusicMVC.Data.Entities;

namespace MusicMVC.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAXLENGTH_ArtistName);

            builder.Property(c => c.Nickname)
                .HasMaxLength(25);

            builder.HasData(new Entities.Artist
            { Id = Guid.Parse("2a275182-877d-4368-a135-156bea1b685b"), Name = " Name Artist 1", Nickname = ""  });

            builder.HasData(new Entities.Artist
            { Id = Guid.Parse("7e51cdda-b651-4081-b0df-b3ab3e4da734"), Name = " Name Artist 2", Nickname = "" });

            //throw new NotImplementedException();
        }
    }
}
