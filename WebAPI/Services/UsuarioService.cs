using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using WebAPI.DTOs;

namespace WebAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioDAO _usuarioDAO;

        public UsuarioService(UsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        public string? login(loginDTO loginDTO)
        {
            var usuario = _usuarioDAO.login(loginDTO.Username, loginDTO.PasswordHash);
            return usuario?.Username;
        }

        public bool registrar(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var usuario = new Usuario
            {
                Username = usuarioRegistroDTO.Username,
                PasswordHash = usuarioRegistroDTO.PasswordHash,
                Activo = usuarioRegistroDTO.Activo
            };
            return _usuarioDAO.registrar(usuario);
        }
    }
}
