using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Areas.Identity.Data;

namespace MusicMVC.Data;

public class MusicIdentityContext : IdentityDbContext<MusicUser>
{
    public MusicIdentityContext(DbContextOptions<MusicIdentityContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=LAPTOP-M2M74TDG\\SQLEXPRESS;Database=MusicIdentity;User Id=itsjuneka; password=P@ssword123; TrustServerCertificate=True; Trusted_Connection=False; MultipleActiveResultSets=true;";
        optionsBuilder.UseSqlServer(connectionString);

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
