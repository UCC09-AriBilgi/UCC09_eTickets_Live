using eTickets_Web.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get ; set ; }



        [Display(Name = "Cinema Name")] // Viewlardaki ilgili alanın başındaki görünecek text
        [Required(ErrorMessage = "Sinema adı gereklidir...")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema Ad bilgisi 3-50 karakter arasında olmalıdır..")]
        public string Name { get; set; } // Cinema adı


    }
}
