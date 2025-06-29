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
        public IActionResult login([FromBody] loginDTO loginDTO)
        {
            var usuario = _usuarioService.login(loginDTO);

            if (usuario != null)
            {
                var token = _usuarioService.GenerarToken(usuario); //genera token y se envía al usuario
                return Ok(new {exito = true, token, usuario = usuario.Username });
            }
            else
            {
                return Unauthorized(new {exito = false, mensaje = "Usuario o Contraseña incorrectos" });
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

        [HttpPatch("ActualizarUsuario")]
        public IActionResult actualizarUsuario([FromBody] ActualizarUsuarioDTO datos)
        {
            bool hecho = usuariodao.actualizar(datos.Username, datos.PasswordActual, datos.PasswordNueva);

            if (hecho)
            {
                return Ok(new { exito = true, mensaje = "Contraseña actualizada correctamente" });
            }
            else
            {
                return BadRequest(new { exito = false, mensaje = "Error al actualizar la Contraseña" });
            }
        }

        [HttpPost("InsertarUsuario")]
        public IActionResult registrar([FromBody] UsuarioRegistroDTO usuarioRegistroDTO)
        {
            //if (usuarioRegistroDTO == null ||
            //    string.IsNullOrWhiteSpace(usuarioRegistroDTO.Username) || string.IsNullOrWhiteSpace(usuarioRegistroDTO.PasswordHash))
            //{
            //    return BadRequest(new { mensaje = "Datos incompletos" });
            //}

            bool registrado = _usuarioService.registrar(usuarioRegistroDTO);
            if (registrado)
            {
                return Ok(new {exito = true, mensaje = "Usuario registrado correctamente" });
            }
            else
            {
                return BadRequest(new {exito = false, mensaje = "Error al registrar al Usuario" });

            }
        }
    }
}
