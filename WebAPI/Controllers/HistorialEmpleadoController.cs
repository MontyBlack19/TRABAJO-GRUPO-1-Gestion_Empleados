using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class HistorialEmpleadoController : ControllerBase
    {
        private HistorialEmpleadoDAO historialEmpleadoDao = new HistorialEmpleadoDAO();

        [HttpGet("MostrarHistoriales")]
        public List<HistorialEmpleado> mostrarHistorial()
        {
            return historialEmpleadoDao.listar();
        }

        [HttpGet("MostrarHistorialesXId")]
        public HistorialEmpleado mostrarHistorialxId(int id)
        {
            return historialEmpleadoDao.listarId(id);
        }

        [HttpGet("MostrarHistorialesxEmpleado")]
        public List<HistorialEmpleado> mostrarHistorialXEmpleado(int idEmpleado)
        {
            return historialEmpleadoDao.listarIdE(idEmpleado);
        }

        [HttpPost("InsertarHistorialEmpleado")]
        public bool insertarHistorial([FromBody] HistorialEmpleado historial)
        {
            return historialEmpleadoDao.insertar(
                    historial.IdEmpleado,
                    historial.CampoModificado,
                    historial.ValorAnterior,
                    historial.ValorNuevo,
                    historial.ModificadoPor
                );
        }

        [HttpPut("ActualizarHistorialEmpleado")]
        public bool actualizarHistorial([FromBody]HistorialEmpleado historial)
        {
            return historialEmpleadoDao.actualizar(
                    historial.IdHistorial,
                    historial.IdEmpleado,
                    historial.CampoModificado,
                    historial.ValorAnterior,
                    historial.ValorNuevo,
                    historial.FechaModificacion,
                    historial.ModificadoPor
                );
        }

        [HttpDelete("EliminarHistorialEmpleado")]
        public bool eliminarHistorial(int id)
        {
            return historialEmpleadoDao.eliminar(id);
        }
    }
}
