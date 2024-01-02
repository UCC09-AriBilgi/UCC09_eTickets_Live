using eTickets_Web.Models;

namespace eTickets_Web.Data.ViewModels
{
    // Kullanılacak dropdownlar
    public class NewMovieDropdownsVM
    {
        // Değişkenler
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }

        // Constructor
        public NewMovieDropdownsVM() 
        { 
            // Select List lerde kullanacağım listeler

            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }    

    }
}
