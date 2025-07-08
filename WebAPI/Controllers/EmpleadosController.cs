using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebAPI.DTOs;

namespace Web_App.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadoService _service;

        public EmpleadosController(EmpleadoService service)
        {
            _service = service;
        }

        private EmpleadoDAO empleadoDAO = new EmpleadoDAO();

        [HttpGet("ListaEmpleados")]
        public List<EmpleadoDTO> seleccionarEmpleados()
        {
            return _service.seleccionarEmpleados();
        }

        [HttpPut("ActualizarEmpleado")]
        public IActionResult actualizarEmpleado([FromBody] Empleado empleado)
        {
            var actualizado = _service.actualizarEmpleado(empleado);
            

            if (actualizado == true)
            {
                return Ok(new { exito = true, mensaje = "Empleado actualizado exitosamente." });
            }
            else
            {
                return BadRequest(new { exito = false, mensaje = "El empleado no fue actualizados" });
            }
        }

        [HttpPost("InsertarEmpleado")]
        public IActionResult insertarEmpleado([FromBody] EmpleadoDTO empleadoDTO)
        {
            var agregado = _service.insertarEmpleado(empleadoDTO);

            if (agregado == true)
            {
                return Ok(new { exito = true, mensaje = "Empleado agregado exitosamente." });
            }
            else
            {
                return BadRequest(new { exito = false, mensaje = "El empleado no fue agregado" });
            }
        }
        
        [HttpDelete("EliminarEmpleado")]
        public bool eliminarEmpleado(int id)
        {
            return empleadoDAO.eliminar(id);
        }
    }
}
