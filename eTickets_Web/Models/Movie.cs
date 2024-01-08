using eTickets_Web.Data.Base;
using eTickets_Web.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets_Web.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get ; set ; }

        [Display(Name = "Movie Name")] // Viewlardaki ilgili alanın başındaki görünecek text
        public string? Name { get; set; } // Cinema adı

        [Display(Name = "Description")] // Viewlardaki ilgili alanın başındaki görünecek text
        public string? Description { get; set; }

        [Display(Name = "Ticket Price")] // Viewlardaki ilgili alanın başındaki görünecek text
        public double Price { get; set; }

        [Display(Name = "Affiche")] // Viewlardaki ilgili alanın başındaki görünecek text
        public string? ImageURL { get; set; }

        [Display(Name = "Start Date")] // Viewlardaki ilgili alanın başındaki görünecek text
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")] // Viewlardaki ilgili alanın başındaki görünecek text
        public DateTime EndDate  { get; set; }

        public MovieCategory MovieCategory { get; set; } // Enum bilgiler
        //Relationships
        // Many-to-many
        public List<Actor_Movie>? Actors_Movies { get; set; }

        // One to Many - Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema? Cinema { get; set; }

        // One to Many - Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer? Producer { get; set;}


    }
}
