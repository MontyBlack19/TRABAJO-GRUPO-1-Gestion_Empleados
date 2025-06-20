using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Services;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("IniciarSesion")]
        public IActionResult login([FromBody]loginDTO loginDTO)
        {
             var usuario = _usuarioService.login(loginDTO);

            if (usuario != null)
            {
                return Ok(new { usuario });
            }
            else
            {
                return Unauthorized(new {mensaje = "Usuario o Contraseña incorrecto.s"});
            }
            
        }

        private UsuarioDAO usuariodao = new UsuarioDAO();

        [HttpGet("ListarUsuarios")]
        public List<Usuario> mostrarUsuarios()
        {
            return usuariodao.listar();
        }

        [HttpDelete("EliminarUsuario")]
        public bool eliminarUsuario(int id)
        {
            return usuariodao.eliminar(id);
        }

        [HttpPut("ActualizarUsuario")]
        public bool actualizarUsuario(int id, bool activo)
        {
            return usuariodao.actualizar(id, activo);
        }

        [HttpPost("InsertarUsuario")]
        public IActionResult registrar([FromBody] UsuarioRegistroDTO usuarioRegistroDTO)
        {
            if (usuarioRegistroDTO == null ||
                string.IsNullOrWhiteSpace(usuarioRegistroDTO.Username) || string.IsNullOrWhiteSpace(usuarioRegistroDTO.PasswordHash))
            {
                return BadRequest(new { mensaje = "Datos incompletos" });
            }

            bool registrado = _usuarioService.registrar(usuarioRegistroDTO);
            if (registrado)
            {
                return Ok(new { mensaje = "Usuario registrado correctamente" });
            }
            else
            {
                return BadRequest(new { mensaje = "Error al registrar al Usuarios" });

            }
        }
    }
}
