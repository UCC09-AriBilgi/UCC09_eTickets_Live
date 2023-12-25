using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name="FullName")]
        public string FullName { get; set; }
    }
}
