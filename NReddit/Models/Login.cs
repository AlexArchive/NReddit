using System.ComponentModel.DataAnnotations;

namespace NReddit.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}