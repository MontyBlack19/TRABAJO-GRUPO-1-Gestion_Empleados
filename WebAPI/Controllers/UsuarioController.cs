using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioDAO usuariodao = new UsuarioDAO();

        [HttpPost("IniciarSesion")]
        public string logins([FromBody]Usuario u)
        {
             var inicio = usuariodao.login(u.Username, u.PasswordHash);
            if (inicio != null)
            {
                return inicio.Username;
            }
            else
            {
                return null;
            }
            
        }

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
        public bool insertarUsuario(string user)
        {
            return usuariodao.insertar(user);
        }
    }
}
