using System.ComponentModel.DataAnnotations;

namespace TestI.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
