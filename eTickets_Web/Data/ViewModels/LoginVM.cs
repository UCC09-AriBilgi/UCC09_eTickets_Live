using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="EMail Address")]
        [Required(ErrorMessage = "EMail adresi gereklidir....")]
        public string EMailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Şifre gereklidir...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
