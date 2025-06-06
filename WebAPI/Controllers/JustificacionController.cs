using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class JustificacionController : ControllerBase
    {
        private JustificacionDAO justificacionDAO = new JustificacionDAO();

        [HttpGet("MostrarJustificaciones")]
        public List<Justificacion> mostrarJustificacion()
        {
            return justificacionDAO.listar();
        }

        [HttpPut("ActualizarJustificaciones")]
        public bool actualizarJustificaciones([FromBody]Justificacion justificacion)
        {
            return justificacionDAO.actualizar(
                justificacion.IdJustificacion,
                justificacion.IdEmpleado,
                justificacion.Fecha,
                justificacion.Motivo,
                justificacion.AprobadoPor,
                justificacion.FechaAprobacion,
                justificacion.CreadoPor
            );
        }

        [HttpPost("InsertarJustificaciones")]
        public bool insertarJustificacion([FromBody]Justificacion justificacion)
        {
            return justificacionDAO.insertar(
                justificacion.IdEmpleado,
                justificacion.Fecha,
                justificacion.Motivo,
                justificacion.AprobadoPor,
                justificacion.FechaAprobacion,
                justificacion.CreadoPor
            );
        }

        [HttpDelete("EliminarJustificacion")]
        public bool eliminarJustificacion(int id)
        {
            return justificacionDAO.eliminar(id);
        }
    }
}
