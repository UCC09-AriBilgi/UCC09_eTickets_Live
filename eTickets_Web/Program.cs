using eTickets_Web.Data;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Models;
using eTickets_Web.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // DbContext Configuration
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))); // appsettings.json daki Conn tanýmýný al

        // Service Configuration
        // Scoped (Kapsamlý) : Her service kapsamý için yeni bir instance(örnek) oluþturulur.
        // peakup.org
        //builder.Services.AddScoped<IActorsService, ActorsService>();
        //builder.Services.AddScoped<IProducersService, ProducersService>();
        //builder.Services.AddScoped<ICinemasService, CinemasService>();
        //builder.Services.AddScoped<IMoviesService, MoviesService>();

        // Authentication and Authorization
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddAuthorization(options => {
            //options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        });


        //

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

        // Seeding Database - Örnek datalarý oluþturulmasý

        //AppDbInitializer.Seed(app); // user data
        //AppDbInitializer.SeedUsersAndRolesAsync(app).Wait(); // user auth ????????

        app.Run();
    }
}