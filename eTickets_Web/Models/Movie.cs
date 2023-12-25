using eTickets_Web.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get ; set ; }

        [Display(Name = "Movie Name")] // Viewlardaki ilgili alanın başındaki görünecek text
        public string Name { get; set; } // Cinema adı

        [Display(Name = "Description")] // Viewlardaki ilgili alanın başındaki görünecek text
        public string Description { get; set; }

        [Display(Name = "Ticket Price")] // Viewlardaki ilgili alanın başındaki görünecek text
        public double Price { get; set; }

        [Display(Name = "Affiche")] // Viewlardaki ilgili alanın başındaki görünecek text
        public string ImageURL { get; set; }

        [Display(Name = "Start Date")] // Viewlardaki ilgili alanın başındaki görünecek text
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")] // Viewlardaki ilgili alanın başındaki görünecek text
        public DateTime EndDate  { get; set; }

        //Eklenecekler var
    }
}
