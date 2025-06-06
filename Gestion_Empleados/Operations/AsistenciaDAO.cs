using Gestion_Empleados.Context;
using Gestion_Empleados.Models;

namespace Gestion_Empleados.Operations
{
    public class AsistenciaDAO
    {
        private readonly GestionEmpleados3Context contexto = new GestionEmpleados3Context();

        public List<Asistencium> SeleccionarTodas()
        {
            return contexto.Asistencia.ToList();
        }

        public Asistencium SeleccionarPorId(int id)
        {
            return contexto.Asistencia.FirstOrDefault(a => a.IdAsistencia == id);
        }

        public bool Insertar(Asistencium asistencia)
        {
            try
            {
                contexto.Asistencia.Add(asistencia);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool Actualizar(Asistencium asistencia)
        {
            try
            {
                var existente = contexto.Asistencia.FirstOrDefault(a => a.IdAsistencia == asistencia.IdAsistencia);

                if (existente == null)
                    return false; 

                existente.Fecha = asistencia.Fecha;
                existente.HoraEntrada = asistencia.HoraEntrada;
                existente.HoraSalida = asistencia.HoraSalida;
                existente.Justificada = asistencia.Justificada;
                existente.IdEmpleado = asistencia.IdEmpleado;
                existente.CreadoPor = asistencia.CreadoPor;

                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar asistencia: " + ex.Message);
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var asistencia = SeleccionarPorId(id);
                if (asistencia == null) return false;

                contexto.Asistencia.Remove(asistencia);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
