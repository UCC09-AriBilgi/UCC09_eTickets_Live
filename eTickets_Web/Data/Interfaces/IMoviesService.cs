﻿using eTickets_Web.Data.Base;
using eTickets_Web.Data.ViewModels;
using eTickets_Web.Models;

namespace eTickets_Web.Data.Interfaces
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Movie GetMovieById(int id);

        // ilerleyen kısımlarda özellikle View tarafın kullanacağımız View-Models(VM) de kullanılmak üzere

        // Yeni bir movie tanımlada kullanılacak dropdownlist yapıları
        NewMovieDropdownsVM GetNewMovieDropdownsValues();

        Movie AddNewMovie(NewMovieVM data);

        Movie UpdateMovie(NewMovieVM data);
    }
}
