using eTickets_Web.Models;
using eTickets_Web.Enums;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using eTickets_Web.Static;

namespace eTickets_Web.Data
{
    // Burası VT yaratılırken Dummy veriyle yaratılması için
    // Servis yapısı kullanılacak
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // Kapsam belirleniyor
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context=serviceScope.ServiceProvider.GetService<AppDbContext>(); // AppDbContext imi bir servis olarak alıyorum.

                // Db var mı / yok mu
                context.Database.EnsureCreated(); // VT varmı/yokmu

                //Cinema table için dummy data
                if (!context.Cinemas.Any()) // tablonun içinde herhangi bir kayıt var mı / yok mu
                {
                    // Kayıt yok ...gel buraya
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        // Örnek data kısmı
                        new Cinema()
                        {
                            Name="Cinema1",
                            Logo="http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description="This is Cinema1"
                        },
                        new Cinema()
                        {
                            Name="Cinema2",
                            Logo="http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description="This is Cinema2"
                        },
                        new Cinema()
                        {
                            Name="Cinema3",
                            Logo="http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description="This is Cinema3"
                        },
                        new Cinema()
                        {
                            Name="Cinema4",
                            Logo="http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description="This is Cinema4"
                        },
                        new Cinema()
                        {
                            Name="Cinema5",
                            Logo="http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description="This is Cinema5"
                        }
                    });

                    context.SaveChanges(); // Örnek Cinema datası yazıldı.


                }

                //Actor table için dummy data
                if (!context.Actors.Any()) // tablonun içinde herhangi bir kayıt var mı / yok mu
                {
                    // Kayıt yok ...gel buraya
                    context.Actors.AddRange(new List<Actor>()
                    {
                        // Örnek data kısmı
                        new Actor()
                        {
                            FullName="Actor1",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-1.jpeg",
                            Bio="This is Bio for Actor1"
                        },
                        new Actor()
                        {
                            FullName="Actor2",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-2.jpeg",
                            Bio="This is Bio for Actor2"
                        },
                        new Actor()
                        {
                            FullName="Actor3",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-3.jpeg",
                            Bio="This is Bio for Actor3"
                        },
                        new Actor()
                        {
                            FullName="Actor4",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-4.jpeg",
                            Bio="This is Bio for Actor4"
                        },
                                                                                                                          new Actor()
                        {
                            FullName="Actor5",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-5.jpeg",
                            Bio="This is Bio for Actor5"
                        },
                    });

                    context.SaveChanges(); // Örnek Actor datası yazıldı.


                }

                //Producers table için dummy data
                if(!context.Producers.Any())
                {
                    // Kayıt yok ...gel buraya
                    context.Producers.AddRange(new List<Producer>()
                    {
                        // Örnek data kısmı
                        new Producer()
                        {
                            FullName="Producer1",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-1.jpeg",
                            Bio="This is Bio for Producer1"
                        },
                        new Producer()
                        {
                            FullName="Producer2",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-2.jpeg",
                            Bio="This is Bio for Producer2"
                        },
                                                new Producer()
                        {
                            FullName="Producer3",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-3.jpeg",
                            Bio="This is Bio for Producer3"
                        },
                                                                        new Producer()
                        {
                            FullName="Producer4",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-3.jpeg",
                            Bio="This is Bio for Producer4"
                        },
                                                                        new Producer()
                        {
                            FullName="Producer5",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-5.jpeg",
                            Bio="This is Bio for Producer5"
                        },
                    });

                    context.SaveChanges(); // Örnek Producer datası yazıldı.
                }

                //Movies table için dummy data
                if (!context.Movies.Any())
                {
                    // Kayıt yok ...gel buraya
                    context.Movies.AddRange(new List<Movie>()
                    {
                        // Örnek data kısmı
                        new Movie()
                        {
                            Name="Life",
                            Description="This is the Life movie description",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(10),
                            CinemaId=3,
                            ProducerId=3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name="The Shawnshank Redemption",
                            Description="This is the SR movie description",
                            Price=29.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(30),
                            CinemaId=1,
                            ProducerId=1,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name="Ghost",
                            Description="This is the Ghost movie description",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId=4,
                            ProducerId=4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name="Race",
                            Description="This is the Race movie description",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-5),
                            CinemaId=1,
                            ProducerId=2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name="Scoob",
                            Description="This is the Scoob movie description",
                            Price=19.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            CinemaId=1,
                            ProducerId=3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name="Cold Soles",
                            Description="This is the Cold Soles movie description",
                            Price=19.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate=DateTime.Now.AddDays(3),
                            EndDate=DateTime.Now.AddDays(20),
                            CinemaId=1,
                            ProducerId=5,
                            MovieCategory = MovieCategory.Drama
                        },
                    }) ;

                    context.SaveChanges(); // Örnek Movie datası yazıldı.
                }

                //ActorMovies table için dummy data
                if (!context.Actors_Movies.Any())
                {
                    // Kayıt yok ...gel buraya
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        // Örnek data kısmı
                        new Actor_Movie() { ActorId=1, MovieId=1 },
                        new Actor_Movie() { ActorId=3, MovieId=1 },
                        new Actor_Movie() { ActorId=1, MovieId=2 },
                        new Actor_Movie() { ActorId=4, MovieId=2 },
                        new Actor_Movie() { ActorId=1, MovieId=3 },
                        new Actor_Movie() { ActorId=2, MovieId=3 },
                        new Actor_Movie() { ActorId=5, MovieId=3 },
                        new Actor_Movie() { ActorId=1, MovieId=4 },
                        new Actor_Movie() { ActorId=4, MovieId=5 },
                        new Actor_Movie() { ActorId=3, MovieId=5 },
                        new Actor_Movie() { ActorId=4, MovieId=3 },
                    });

                    context.SaveChanges(); // Örnek Movie datası yazıldı.
                }
            } 
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Kullanıcı rolleri (admin,normal kullanıcımı)

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Users

                var UserManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEMail = "admin@etickets.com";

                var adminUser=await UserManager.FindByEmailAsync(adminUserEMail);

                if (adminUser==null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEMail,
                        EmailConfirmed = true
                    };


                }







            }

        }



    }
}
