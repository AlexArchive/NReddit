using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NReddit.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "You can't leave this empty.")]
        [Display(Name = "Username")]
        [Remote("IsUsernameAvailable", "Account", ErrorMessage = "Someone already has that username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You can't leave this empty.")]
        [StringLength(100, ErrorMessage = "Your password is too weak.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "These passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}