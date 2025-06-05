using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private TurnoDAO turnoDAO = new TurnoDAO();

        [HttpGet("turno")]
        public Turno ObtenerTurnoPorId(int id)
        {
            return turnoDAO.SeleccionarPorId(id);
        }

        [HttpGet("turnos")]
        public List<Turno> ObtenerTodos()
        {
            return turnoDAO.SeleccionarTodos();
        }

        [HttpPost("turno")]
        public bool Insertar([FromBody] Turno turno)
        {
            return turnoDAO.Insertar(turno);
        }

        [HttpPut("turno")]
        public bool Actualizar([FromBody] Turno turno)
        {
            return turnoDAO.Actualizar(turno);
        }

        [HttpDelete("turno/{id}")]
        public bool Eliminar(int id)
        {
            return turnoDAO.Eliminar(id);
        }
    }
}
