using eTickets_Web.Base;
using eTickets_Web.Models;

namespace eTickets_Web.Interfaces
{
    public interface IProducersService : IEntityBaseRepository<Producer>
    {
        Movie GetMovieById(int id);

        // ilerleyen kısımlarda özellikle View tarafın kullanacağımız View-Models(VM) de kullanılmak üzere

        //NewMovieDropdownsVM GetNewMovieDropdownsValues();

        //Movie AddNewMovie(NewMovieVM data);

        //Movie UpdateMovie(NewMovieVM data);


    }
}
