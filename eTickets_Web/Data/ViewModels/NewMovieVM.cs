using eTickets_Web.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Data.ViewModels
{
    public class NewMovieVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage ="Film adı  gereklidir...")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Açıklama 5-50 karakter arası olmalıdır")]
        [Required(ErrorMessage = "Açıklama gereklidir...")]
        public string Description { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Fiyat gereklidir...")]
        public double Price { get; set; }

        [Display(Name = "Film Posteri")]
        [Required(ErrorMessage = "Film posteri  gereklidir...")]
        public string ImageURL { get; set; }

        [Display(Name = "Vizyon Tarihi")]
        [Required(ErrorMessage = "Vizyon Tarihi  gereklidir...")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        [Required(ErrorMessage = "Bitiş Tarihi  gereklidir...")]
        public DateTime EndDate { get; set; }

        // Dropdownlar

        [Display(Name = "Film kategorisi")]
        [Required(ErrorMessage = "Kategori gereklidir...")]
        public MovieCategory MovieCategory { get; set; }

        // Relations
        [Display(Name = "Aktör(ler)")]
        [Required(ErrorMessage = "Aktör  gereklidir...")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Sinema")]
        [Required(ErrorMessage = "Sinema  gereklidir...")]
        public int CinemaId { get; set; }

        [Display(Name = "Yönetmen")]
        [Required(ErrorMessage = "Yönetmen  gereklidir...")]
        public int ProducerId { get; set; }

    }
}
