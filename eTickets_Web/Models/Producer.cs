using eTickets_Web.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get ; set ; }

        [Display(Name = "Profil Foto")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Profile picture alanı gereklidir...")]
        public string? ProfilePictureURL { get; set; } // Actor resmi, int den gelecek

        [Display(Name = "Adı Soyadı")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Tam ad alanı gereklidir...")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ad bilgisi 3-50 karakter arasında olmalıdır..")]
        public string? FullName { get; set; } // Actor tam adı

        [Display(Name = "Biography")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Biography alanı gereklidir...")]
        public string? Bio { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; } // bir producer ın birçok filmi olabilir..
        // ? anlamı eğer öyle bir veri yoksa bile(gelmemişse model üzerinden) dikkate alma
    }
}
