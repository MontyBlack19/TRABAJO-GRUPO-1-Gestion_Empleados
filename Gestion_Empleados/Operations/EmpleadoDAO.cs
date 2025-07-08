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
        public bool insertar(Empleado empleado)
        {
            try
            {
                empleado.Activo = true;
                Contexto.Empleados.Add(empleado);
                Contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool actualizar(Empleado empleado)
        {
            try
            {
                var existe = Contexto.Empleados.FirstOrDefault(e => e.IdEmpleado == empleado.IdEmpleado);
                
                if (existe == null)
                {
                    return false;
                }
                else
                {
                    existe.Nombre = empleado.Nombre;
                    existe.Apellido = empleado.Apellido;
                    existe.Correo = empleado.Correo;
                    existe.Telefono = empleado.Telefono;
                    existe.FechaIngreso = empleado.FechaIngreso;
                    existe.IdTipo = empleado.IdTipo;
                    existe.IdDepartamento = empleado.IdDepartamento;
                    existe.IdTurno = empleado.IdTurno;
                    existe.IdSucursal = empleado.IdSucursal;
                    existe.Activo = empleado.Activo;
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
