using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operations
{
    public class TipoEmpleadoDAO
    {

        public GestionEmpleados3Context contexto = new GestionEmpleados3Context();

        public List<TipoEmpleado> seleccionarTodos()
        {
            var tipoempleado = contexto.TipoEmpleados.ToList<TipoEmpleado>();
            return tipoempleado;
        }

        public TipoEmpleado seleccionarTipoEmpleado(int id)
        {
            var tipoempleado = contexto.TipoEmpleados.Where(te => te.IdTipo == id).FirstOrDefault();

            return tipoempleado;
        }

        public TipoEmpleado seleccionarTipoEmpleadoPorNombre(string nombre)
        {
            var tipoempleado = contexto.TipoEmpleados.Where(t => t.NombreTipo.Equals(nombre)).FirstOrDefault();

            return tipoempleado;
        }

        public bool insertar(string nombretipo)
        {
            try
            {
                TipoEmpleado tipoempleado = new TipoEmpleado();

                tipoempleado.NombreTipo = nombretipo;

                contexto.TipoEmpleados.Add(tipoempleado);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool actualizar(int id, string nombretipo)
        {
            try
            {
                var tipoempleado = seleccionarTipoEmpleado(id);

                if (tipoempleado == null)
                {
                    return false;
                }
                else
                {
                    tipoempleado.IdTipo = id;
                    tipoempleado.NombreTipo = nombretipo;

                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var tipoempleado = seleccionarTipoEmpleado(id);

                if (tipoempleado == null)
                {
                    return false;
                }
                else
                {
                    contexto.TipoEmpleados.Remove(tipoempleado);
                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<EmpleadoTipo> seleccionarEmpleadosTipo()
        {
            var query = from e in contexto.Empleados
                        join t in contexto.TipoEmpleados on e.IdTipo equals t.IdTipo
                        select new EmpleadoTipo
                        {
                            NombreEmpleado = e.Nombre,
                            NombreTipo = t.NombreTipo
                        };

            return query.ToList();
        }
    }
}
