using System.ComponentModel.DataAnnotations;

namespace TestI.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
