namespace WebAPI.DTOs
{
    public class UsuarioRegistroDTO
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
