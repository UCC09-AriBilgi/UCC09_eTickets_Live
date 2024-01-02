using eTickets_Web.Data.Base;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Models;

namespace eTickets_Web.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context)
        {
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
