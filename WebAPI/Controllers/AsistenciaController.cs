using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private AsistenciaDAO asistenciaDAO = new AsistenciaDAO();

        [HttpGet("asistencia")]
        public Asistencium ObtenerAsistenciaPorId(int id)
        {
            return asistenciaDAO.SeleccionarPorId(id);
        }

        [HttpGet("asistencias")]
        public List<Asistencium> ObtenerTodas()
        {
            return asistenciaDAO.SeleccionarTodas();
        }

        [HttpPost("asistencia")]
        public bool Insertar([FromBody] Asistencium asistencia)
        {
            return asistenciaDAO.Insertar(asistencia);
        }

        [HttpPut("asistencia")]
        public bool Actualizar([FromBody] Asistencium asistencia)
        {
            return asistenciaDAO.Actualizar(asistencia);
        }

        [HttpDelete("asistencia/{id}")]
        public bool Eliminar(int id)
        {
            return asistenciaDAO.Eliminar(id);
        }
    }
}
