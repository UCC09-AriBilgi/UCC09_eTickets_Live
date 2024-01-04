using eTickets_Web.Data.Base;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Data.ViewModels;
using eTickets_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets_Web.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;


        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Movie AddNewMovie(NewMovieVM data)
        {
            // base Movie data
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId=data.CinemaId,
                StartDate= data.StartDate,
                EndDate=data.EndDate,
                MovieCategory=data.MovieCategory,
                ProducerId=data.ProducerId
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            // Movie Actorleri için
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    ActorId = actorId,
                    MovieId = newMovie.Id
                };

                _context.Actors_Movies.Add(newActorMovie);

            }

            _context.SaveChanges();

            return newMovie;


        }

        public Movie GetMovieById(int id)
        {
            // İlişkilendirme
            var movieDetails=_context.Movies
                .Include(c=>c.Cinema) // Inner join
                .Include(p=>p.Producer)
                .Include(acmo=> acmo.Actors_Movies)
                .ThenInclude(a=> a.Actor)
                .FirstOrDefault(n=> n.Id == id);


            return movieDetails;
        }

        public NewMovieDropdownsVM GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors=_context.Actors.OrderBy(n=> n.FullName).ToList(),
                Cinemas=_context.Cinemas.OrderBy(n=> n.Name).ToList(),
                Producers=_context.Producers.OrderBy(n=> n.FullName).ToList()
            };

            return response;
        }

        public Movie UpdateMovie(NewMovieVM data)
        {
            var dbMovie=_context.Movies.FirstOrDefault(n=> n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name= data.Name;
                dbMovie.Description= data.Description;
                dbMovie.Price= data.Price;
                dbMovie.ImageURL= data.ImageURL;
                dbMovie.CinemaId= data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate= data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId= data.ProducerId;

                _context.SaveChanges();

            }

            // Junction table daki o film için var olan tüm actorlerin silinmesi.ekrandan alınanların yazılması..
            var existingActorsDb=_context.Actors_Movies
                                .Where(n=> n.MovieId ==data.Id).ToList(); 
            
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            _context.SaveChanges();

            // yenileri için
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    ActorId = actorId,
                    MovieId = data.Id
                };

                _context.Actors_Movies.Add(newActorMovie);

            }

            _context.SaveChanges();

            return dbMovie;

        }
    }
}
