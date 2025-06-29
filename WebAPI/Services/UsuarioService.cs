using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;


namespace WebAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioDAO _usuarioDAO;
        private readonly IConfiguration _configuration;

        public UsuarioService(UsuarioDAO usuarioDAO, IConfiguration configuration)
        {
            _usuarioDAO = usuarioDAO;
            _configuration = configuration;
        }

        public Usuario? login(loginDTO loginDTO)
        {
            var usuario = _usuarioDAO.login(loginDTO.Username, loginDTO.PasswordHash);
            return usuario;
        }

        public string GenerarToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);  //seguridad implementada en caso de inyecciones de keys no emitidas por el servidor
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor // asigna el token y almacena en usuario con su id para evitar repetidos 
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) //asegura que no sea falsificado 
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); //crea en memoria
            return tokenHandler.WriteToken(token); //convierte cadena y envía al front
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

        public bool actualizar(ActualizarUsuarioDTO auDTO)
        {
            var usuario = _usuarioDAO.login(auDTO.Username, auDTO.PasswordActual);
            if (usuario == null)
            {
                return false;
            }
            return _usuarioDAO.actualizar(auDTO.Username, auDTO.PasswordActual ,auDTO.PasswordNueva);
        }
    }
}
