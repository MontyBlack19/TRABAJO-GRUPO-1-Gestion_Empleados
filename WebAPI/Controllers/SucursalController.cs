using AccesoDatos.Operaciones;
using Gestion_Empleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private SucursalDAO sucursalDAO = new SucursalDAO();

        [HttpGet("sucursal")]
        public Sucursal seleccionarSucursalPorNombre(int id)
        {
            return sucursalDAO.seleccionarSucursal(id);
        }

        [HttpPut("sucursal")]
        public bool actualizarSucursal([FromBody] Sucursal sucursal)
        {
            return sucursalDAO.actualizar(
                sucursal.IdSucursal,
                sucursal.Nombre,
                sucursal.Direccion,
                sucursal.Telefono
            );
        }

        [HttpPost("sucursal")]
        public bool insertarSucursal([FromBody] Sucursal sucursal)
        {
            return sucursalDAO.insertar(
                sucursal.Nombre,
                sucursal.Direccion,
                sucursal.Telefono
            );
        }

        [HttpDelete("sucursal")]
        public bool eliminarSucursal(int id)
        {
            return sucursalDAO.eliminar(id);
        }
    }
}
