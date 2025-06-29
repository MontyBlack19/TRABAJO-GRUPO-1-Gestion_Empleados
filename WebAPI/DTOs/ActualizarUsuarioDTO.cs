using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class ActualizarUsuarioDTO
    {
        [Required(ErrorMessage = "Usuario obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Usuario obligatorio")]
        public string PasswordActual { get; set; }

        [Required(ErrorMessage = "Usuario obligatorio")]
        public string PasswordNueva { get; set; }

    }
}
