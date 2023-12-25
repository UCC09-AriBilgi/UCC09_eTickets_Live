using eTickets_Web.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get ; set ; }

        [Display(Name = "Profile Picture")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Profile picture alanı gereklidir...")]
        public string ProfilePictureURL { get; set; } // Actor resmi, int den gelecek

        [Display(Name = "Full Name")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Tam ad alanı gereklidir...")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ad bilgisi 3-50 karakter arasında olmalıdır..")]
        public string FullName { get; set; } // Actor tam adı

        [Display(Name = "Biography")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Biography alanı gereklidir...")]
        public string Bio { get; set; }

        // Eklenecekler var
    }
}
