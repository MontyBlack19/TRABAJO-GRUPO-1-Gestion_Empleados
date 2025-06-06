using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operations
{
    public class HistorialEmpleadoDAO
    {
        public GestionEmpleados3Context context = new GestionEmpleados3Context();

        //Listar tidos los datos de la tabla Historia Empleado
        public List<HistorialEmpleado> listar()
        {
            var hEmpleado = context.HistorialEmpleados.ToList<HistorialEmpleado>();
            return hEmpleado;
        }

        //Listar por id de historial
        public HistorialEmpleado listarId(int idHistorial)
        {
            var historial = context.HistorialEmpleados.Where(he => he.IdHistorial == idHistorial).FirstOrDefault();

            return historial;
        }

        //Listar el o los cambios del Historial de un Empleado
        public List<HistorialEmpleado> listarIdE(int idEmpleado)
        {
            var empleado = context.HistorialEmpleados.Where(he => he.IdEmpleado == idEmpleado).ToList<HistorialEmpleado>();

            return empleado;
        }

        public bool insertar(int idEmpleado, string campo, string valorA, string valorB, int usuario)
        {
            try
            {
                HistorialEmpleado historial = new HistorialEmpleado();
                historial.IdEmpleado = idEmpleado;
                historial.CampoModificado = campo;
                historial.ValorAnterior = valorA;
                historial.ValorNuevo = valorB;
                historial.FechaModificacion = new DateTime();
                historial.ModificadoPor = usuario;

                context.HistorialEmpleados.Add(historial);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool actualizar(int idHistorial, int idEmpleado, string campo, string valorA, string valorB, DateTime fecha, int modificado)
        {
            try
            {
                var empleado = listarId(idHistorial);

                if (empleado == null)
                {
                    return false;
                }
                else
                {
                    empleado.IdHistorial = idHistorial;
                    empleado.IdEmpleado = idEmpleado;
                    empleado.CampoModificado = campo;
                    empleado.ValorAnterior = valorA;
                    empleado.ValorNuevo = valorB;
                    empleado.FechaModificacion = fecha;
                    empleado.ModificadoPor = modificado;

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
                var eliminarH = listarId(id);

                if (eliminarH == null)
                {
                    return false;
                }
                else
                {
                    context.HistorialEmpleados.Remove(eliminarH);
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