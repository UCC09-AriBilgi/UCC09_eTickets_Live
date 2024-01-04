using eTickets_Web.Data.Base;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Data.ViewModels;
using eTickets_Web.Models;

namespace eTickets_Web.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context)
        {
        }

        public Movie AddNewMovie(NewMovieVM data)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public NewMovieDropdownsVM GetNewMovieDropdownsValues()
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(NewMovieVM data)
        {
            throw new NotImplementedException();
        }
    }
}
