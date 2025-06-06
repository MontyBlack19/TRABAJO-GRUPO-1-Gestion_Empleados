using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private EmpleadoDAO empleadoDAO = new EmpleadoDAO();

        [HttpGet("empleado")]
        public Empleado seleccionarEmpleadoPorNombre(int id)
        {
            return empleadoDAO.seleccionarEmpleado(id);
        }

        [HttpPut("empleado")]
        public bool actualizarEmpleado([FromBody] Empleado empleado)
        {
            return empleadoDAO.actualizar(
                empleado.IdEmpleado,
                empleado.Nombre,
                empleado.Apellido,
                empleado.Correo,
                empleado.Telefono,
                empleado.FechaIngreso,
                empleado.IdTipo,
                empleado.IdDepartamento,
                empleado.IdTurno,
                empleado.IdSucursal
            );
        }

        [HttpPost("empleado")]
        public bool insertarEmpleado([FromBody] Empleado empleado)
        {
            return empleadoDAO.insertar(              
                empleado.Nombre,
                empleado.Apellido,
                empleado.Correo,
                empleado.Telefono,
                empleado.FechaIngreso,
                empleado.IdTipo,
                empleado.IdDepartamento,
                empleado.IdTurno,
                empleado.IdSucursal
            );
        }

        [HttpDelete("empleado")]
        public bool eliminarEmpleado(int id)
        {
            return empleadoDAO.eliminar(id);
        }
    }
}
