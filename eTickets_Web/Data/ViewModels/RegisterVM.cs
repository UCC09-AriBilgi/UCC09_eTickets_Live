using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Adınız ve Soyadız")]
        [Required(ErrorMessage = "Ad Soyad bilgisi gereklidir....")]
        public string FullName { get; set; }

        [Display(Name = "EMail Adresi")]
        [Required(ErrorMessage = "EMail adresi gereklidir...")]
        public string EMailAddress { get; set; }

        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre gereklidir...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifreniz (tekrar)")]
        [Required(ErrorMessage = "Şifre (tekrar) gereklidir...")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreleriniz uyuşmuyor....")]
        public string ConfirmPassword { get; set; }
    }
}
