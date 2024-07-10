using Microsoft.EntityFrameworkCore;
using MusicMVC.Data;
using Microsoft.AspNetCore.Identity;
using MusicMVC.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MusicIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'MusicIdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
// AddContext
builder.Services.AddDbContext<MusicDbContext>();
builder.Services.AddDbContext<MusicIdentityContext>();

builder.Services.AddDefaultIdentity<MusicUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MusicIdentityContext>();
/*builder.Services.AddDbContext<MusicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicDbContext")));*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
