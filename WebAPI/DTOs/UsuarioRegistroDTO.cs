using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class UsuarioRegistroDTO
    {
        [Required(ErrorMessage = "Usuario obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Contraseña obligatorio")]
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }
    }
}
