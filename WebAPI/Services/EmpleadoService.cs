using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using WebAPI.DTOs;

namespace WebAPI.Services
{
    public class EmpleadoService
    {
        private readonly EmpleadoDAO _empleadoDAO;
        public EmpleadoService(EmpleadoDAO empleadoDao)
        {
            _empleadoDAO = empleadoDao;
        }

        public List<EmpleadoDTO> seleccionarEmpleados()
        {
            var empleado = _empleadoDAO.seleccionarTodos();
            var empleadoDTO = empleado.Select(e => new EmpleadoDTO
            {
                IdEmpleado = e.IdEmpleado,  
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Correo = e.Correo,
                Telefono = e.Telefono,
                FechaIngreso = e.FechaIngreso,
                IdTipo = e.IdTipo,
                IdDepartamento = e.IdDepartamento,
                IdTurno = e.IdTurno,
                IdSucursal = e.IdSucursal,
                Activo = e.Activo
            }).ToList();

            return empleadoDTO;
        }

        public bool insertarEmpleado(EmpleadoDTO empleadoDTO)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoDTO.Nombre,
                Apellido = empleadoDTO.Apellido,
                Correo = empleadoDTO.Correo,
                Telefono = empleadoDTO.Telefono,
                FechaIngreso = empleadoDTO.FechaIngreso,
                IdTipo = empleadoDTO.IdTipo,
                IdDepartamento = empleadoDTO.IdDepartamento,
                IdTurno = empleadoDTO.IdTurno,
                IdSucursal = empleadoDTO.IdSucursal
            };
            
            var insertado = _empleadoDAO.insertar(empleado);

            return insertado;
            
        }

        public bool actualizarEmpleado(Empleado empleado)
        {
            var actualizado = _empleadoDAO.actualizar
            (
                empleado
            );
           
            return actualizado;
        }
    }
}
