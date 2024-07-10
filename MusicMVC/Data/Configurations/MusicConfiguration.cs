using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using MusicMVC.Data.Entities;
using System.Reflection.Emit;

namespace MusicMVC.Data.Configurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public MusicConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.FileName)
                .HasMaxLength(100);

            builder.Property(b => b.Lyrics)
                .HasMaxLength(2000);

            builder.HasData( new Entities.Music
             { Id = Guid.NewGuid() , Name  = " Take me to your heart " , Lyrics = "" , ArtistId = Guid.Parse("2a275182-877d-4368-a135-156bea1b685b")});
            builder.HasData(new Entities.Music
            { Id = Guid.NewGuid(), Name = " Hay Trao Cho Toi ", Lyrics = "",  ArtistId = Guid.Parse("7e51cdda-b651-4081-b0df-b3ab3e4da734") });

            //throw new NotImplementedException();


        }


    }
}
