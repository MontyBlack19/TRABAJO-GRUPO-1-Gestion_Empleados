using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class loginDTO
    {
        [Required(ErrorMessage = "Usuario obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Contraseña obligatorio")]
        public string PasswordHash { get; set; }
    }
}
