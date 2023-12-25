using eTickets_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets_Web.Data
{

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        // Models => Db
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options
            ) :base (options)
        {
                
        }

        // Tablolar arası ilişkilerin belirtilmesi
        // Temel sınıftaki metodun yerine kendi yazdığımızın çalışmasını sağlamış oluyoruz..
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkiler
            // junction
            modelBuilder.Entity<Actor_Movie>().HasKey(acmo => new
            {
                acmo.ActorId,acmo.MovieId
            });
            // Not : Karışık gelebilir - Normaldir
            // Actor_Movie <=> Movie relationı
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Movie)
                .WithMany(acmo => acmo.Actors_Movies)
                .HasForeignKey(m => m.MovieId);

            // Actor_Movie <=> Actor relationı
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Actor)
                .WithMany(acmo => acmo.Actors_Movies)
                .HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);

        }

        // Model(table) belirtimleri
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
