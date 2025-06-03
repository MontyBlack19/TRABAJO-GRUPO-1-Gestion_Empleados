using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private DepartamentoDAO departamentoDao = new DepartamentoDAO();

        [HttpGet("ListarDepartamento")]
        public Departamento mostrarDepartamento(int id)
        {
            return departamentoDao.listarId(id);
        }

        [HttpDelete("EliminarDepartamento")]
        public bool eliminarDepartamento(int id)
        {
            return departamentoDao.eliminarDepartamento(id);
        }

        [HttpPut("ActualizarDepartamento")]
        public bool actualizarDepartamento([FromBody]Departamento d)
        {
            return departamentoDao.actualizar(d.IdDepartamento, d.Nombre);
        }

        [HttpPut("InsertarDepartamento")]
        public bool insertarDepartamento([FromBody]Departamento d)
        {
            return departamentoDao.insertar(d.Nombre);
        }

    }

}
