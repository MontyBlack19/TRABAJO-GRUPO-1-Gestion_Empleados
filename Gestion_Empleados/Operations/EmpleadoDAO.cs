using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion_Empleados.Operations
{
    public class EmpleadoDAO
    {
        public GestionEmpleados3Context Contexto = new GestionEmpleados3Context();


        public List<Empleado> seleccionarTodos()
        {
            var empleado = Contexto.Empleados.ToList<Empleado>();
            return empleado;
        }
        public Empleado seleccionarEmpleado(int id)
        {
            var empleado = Contexto.Empleados.Where(a => a.IdEmpleado == id).FirstOrDefault();

            return empleado;
        }
        public bool insertar(string nombre, string apellido, string correo, string telefono, DateTime fechaIngreso, int idTipo, int idDepartamento, int idTurno, int idSucursal)
        {
            try
            {
                Empleado empleado = new Empleado();
                
                empleado.Nombre = nombre;
                empleado.Apellido = apellido;
                empleado.Correo = correo;
                empleado.Telefono = telefono;
                empleado.FechaIngreso = fechaIngreso;
                empleado.IdTipo = idTipo;
                empleado.IdDepartamento = idDepartamento;
                empleado.IdTurno = idTurno;
                empleado.IdSucursal = idSucursal;

                Contexto.Empleados.Add(empleado);
                Contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool actualizar(int idempleado, string nombre, string apellido, string correo, string telefono, DateTime fechaIngreso, int idTipo, int idDepartamento, int idTurno, int idSucursal)
        {
            try
            {
                var empleado = seleccionarEmpleado(idempleado);

                if (empleado == null)
                {
                    return false;
                }
                else
                {
                    empleado.IdEmpleado = idempleado;
                    empleado.Nombre = nombre;
                    empleado.Apellido = apellido;
                    empleado.Correo = correo;
                    empleado.Telefono = telefono;
                    empleado.FechaIngreso = fechaIngreso;
                    empleado.IdTipo = idTipo;
                    empleado.IdDepartamento = idDepartamento;
                    empleado.IdTurno = idTurno;
                    empleado.IdSucursal = idSucursal;

                    Contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int idEmpleado)
        {
            try
            {
                var empleado = seleccionarEmpleado(idEmpleado);

                if (empleado == null)
                {
                    return false;
                }
                else
                {
                    Contexto.Empleados.Remove(empleado);
                    Contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
