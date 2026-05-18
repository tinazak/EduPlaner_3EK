using System.ComponentModel.DataAnnotations;

namespace HAK_BlazorPicoTemplate.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Geben Sie bitte einen Benutzername ein!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Geben Sie bitte ein Passwort ein!")]
        [MinLength(6, ErrorMessage = "Das Passwort muss 6 Zeichen enthalten!")]
        public string Password { get; set; } = string.Empty;
    }
}
