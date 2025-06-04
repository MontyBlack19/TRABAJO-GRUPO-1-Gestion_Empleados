using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TIpoEmpleadoController : ControllerBase
    {
        private TipoEmpleadoDAO tipoempleadoDAO = new TipoEmpleadoDAO();

        [HttpGet("tipoempleado")]
        public TipoEmpleado seleccionarTipoEmpleadoPorNombre(string nombre)
        {
            return tipoempleadoDAO.seleccionarTipoEmpleadoPorNombre(nombre);
        }

        [HttpPut("tipoempleado")]
        public bool actualizarTipoEmpleado([FromBody] TipoEmpleado tipoempleado)
        {
            return tipoempleadoDAO.actualizar(tipoempleado.IdTipo, tipoempleado.NombreTipo);
        }

        [HttpPost("tipoempleado")]
        public bool insertarTipoEmpleado([FromBody] TipoEmpleado tipoempleado)
        {
            return tipoempleadoDAO.insertar(tipoempleado.NombreTipo);
        }

        [HttpDelete("tipoempleado")]
        public bool eliminarTipoEmpleado(int id)
        {
            return tipoempleadoDAO.eliminar(id);
        }
    }
}
