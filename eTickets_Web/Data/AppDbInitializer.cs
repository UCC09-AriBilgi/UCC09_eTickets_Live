using eTickets_Web.Models;
using Microsoft.Extensions.DependencyInjection;

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
                            
                        },

                    }) ;

                    context.SaveChanges(); // Örnek Actor datası yazıldı.
                }
            } 

        }



    }
}
