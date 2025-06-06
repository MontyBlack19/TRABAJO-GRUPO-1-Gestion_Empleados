using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class VacacionesController : ControllerBase
    {
        private VacacionesDAO vacacionesDAO = new VacacionesDAO();

        [HttpGet("vacacionesEmpleado")]
        public Vacacione seleccionarVacacionesPorEmpleado(int id)
        {
            return vacacionesDAO.seleccionarVacacionesPorEmpleado(id);
        }

        [HttpPut("vacaciones")]
        public bool actualizarVacaciones([FromBody] Vacacione vacaciones)
        {
            return vacacionesDAO.actualizar(vacaciones.IdVacacion, vacaciones.IdEmpleado, vacaciones.FechaInicio, vacaciones.FechaFin, vacaciones.AprobadoPor, vacaciones.FechaAprobacion, vacaciones.CreadoPor);
        }

        [HttpPost("vacaciones")]
        public bool insertarVacaciones([FromBody] Vacacione vacaciones)
        {
            return vacacionesDAO.insertar(vacaciones.IdEmpleado, vacaciones.FechaInicio, vacaciones.FechaFin, vacaciones.AprobadoPor, vacaciones.FechaAprobacion, vacaciones.CreadoPor);
        }

        [HttpDelete("vacaciones")]
        public bool eliminarVacaciones(int id)
        {
            return vacacionesDAO.eliminar(id);
        }
    }
}
