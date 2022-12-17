using System.ComponentModel.DataAnnotations;

namespace TestI.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Не указано имя клиента")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Не указан email клиента")]
        public string ClientEmail { get; set; }

        [Required(ErrorMessage = "Не указан телефон клиента")]
        public string Telephone { get; set; }
    }
}
