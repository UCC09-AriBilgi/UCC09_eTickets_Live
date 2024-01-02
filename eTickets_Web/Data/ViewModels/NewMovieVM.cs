using eTickets_Web.Data.Enums;

namespace eTickets_Web.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        // Dropdownlar
        public MovieCategory MovieCategory { get; set; }

    }
}
