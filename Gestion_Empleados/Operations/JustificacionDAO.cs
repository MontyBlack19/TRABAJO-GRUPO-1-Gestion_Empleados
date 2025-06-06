using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operations
{
    public class JustificacionDAO
    {
        public GestionEmpleados3Context context = new GestionEmpleados3Context();

        public List<Justificacion> listar()
        {
            var justificacion = context.Justificacions.ToList<Justificacion>();
            return justificacion;
        }

        public Justificacion listarId(int idJustificacion)
        {
            var justificacion = context.Justificacions.Where(j => j.IdJustificacion == idJustificacion).FirstOrDefault();
            return justificacion;
        }

        public bool insertar(int idEmpleado, DateTime fecha, string motivo, int aprobadoX, DateTime fechaApro, int creadoX)
        {
            try
            {
                Justificacion justificacion = new Justificacion();
                justificacion.IdEmpleado = idEmpleado;
                justificacion.Fecha = fecha;
                justificacion.Motivo = motivo;
                justificacion.AprobadoPor = aprobadoX;
                justificacion.FechaAprobacion = fechaApro;
                justificacion.CreadoPor = creadoX;

                context.Justificacions.Add(justificacion);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool actualizar(int idJustificacion, int idEmpleado, DateTime fecha, string motivo, int aprobadoX, DateTime fechaApro, int creadoX)
        {
            try
            {
                var justificacion = listarId(idJustificacion);

                if (justificacion == null)
                {
                    return false;
                }
                else
                {
                    justificacion.IdJustificacion = idJustificacion;
                    justificacion.IdEmpleado = idEmpleado;
                    justificacion.Fecha = fecha;
                    justificacion.Motivo = motivo;
                    justificacion.AprobadoPor = aprobadoX;
                    justificacion.FechaAprobacion = fechaApro;
                    justificacion.CreadoPor = creadoX;

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var justificacion = listarId(id);

                if (justificacion == null)
                {
                    return false;
                }
                else
                {
                    context.Justificacions.Remove(justificacion);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
