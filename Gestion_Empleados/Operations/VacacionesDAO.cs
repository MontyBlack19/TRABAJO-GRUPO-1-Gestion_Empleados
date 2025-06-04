using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operations
{
    public class VacacionesDAO
    {
        public GestionEmpleados3Context contexto = new GestionEmpleados3Context();

        public Vacacione seleccionarVacaciones(int id)
        {
            var vacaciones = contexto.Vacaciones.Where(v => v.IdVacacion == id).FirstOrDefault();

            return vacaciones;
        }

        public Vacacione seleccionarVacacionesPorEmpleado(int id)
        {
            var vacaciones = contexto.Vacaciones.Where(v => v.IdEmpleado == id).FirstOrDefault();

            return vacaciones;
        }

        public bool insertar(int idEmpleado, DateOnly fechaInicio, DateOnly fechaFin, int aprobacion, DateTime fechaAprobacion, int creacion)
        {
            try
            {
                Vacacione vacaciones = new Vacacione();

                vacaciones.IdEmpleado = idEmpleado;
                vacaciones.FechaInicio = fechaInicio;
                vacaciones.FechaFin = fechaFin;
                vacaciones.AprobadoPor = aprobacion;
                vacaciones.FechaAprobacion = fechaAprobacion;
                vacaciones.CreadoPor = creacion;

                contexto.Vacaciones.Add(vacaciones);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool actualizar(int id, int idEmpleado, DateOnly fechaInicio, DateOnly fechaFin, int aprobacion, DateTime fechaAprobacion, int creacion)
        {
            try
            {
                var vacaciones = seleccionarVacaciones(id);

                if (vacaciones == null)
                {
                    return false;
                }
                else
                {
                    vacaciones.IdVacacion = id;
                    vacaciones.IdEmpleado = idEmpleado;
                    vacaciones.FechaInicio = fechaInicio;
                    vacaciones.FechaFin = fechaFin;
                    vacaciones.AprobadoPor = aprobacion;
                    vacaciones.FechaAprobacion = fechaAprobacion;
                    vacaciones.CreadoPor = creacion;

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
                var vacaciones = seleccionarVacaciones(id);

                if (vacaciones == null)
                {
                    return false;
                }
                else
                {
                    contexto.Vacaciones.Remove(vacaciones);
                    contexto.SaveChanges();

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
