using Microsoft.EntityFrameworkCore;
using MusicMVC.Data.Configurations;
using MusicMVC.Data.Entities;
using System.Reflection.Metadata;

namespace MusicMVC.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=LAPTOP-M2M74TDG\\SQLEXPRESS;Database=MusicDbContext;User Id=itsjuneka; password=Quynhnhu@14; TrustServerCertificate=True; Trusted_Connection=False; MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connectionString);
           
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder
                .ApplyConfiguration(new MusicConfiguration());
            Builder
                .ApplyConfiguration(new ArtistConfiguration());
            Builder
                .ApplyConfiguration(new MediumConfiguration());
            Builder
                .ApplyConfiguration(new OrderConfiguration());
            Builder
                .ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Medium> Media { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
