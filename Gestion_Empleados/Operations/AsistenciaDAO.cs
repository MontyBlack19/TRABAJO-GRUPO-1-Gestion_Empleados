using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Asistencium asistencia)
        {
            try
            {
                var existente = SeleccionarPorId(asistencia.IdAsistencia);
                if (existente == null) return false;

                existente.IdEmpleado = asistencia.IdEmpleado;
                existente.Fecha = asistencia.Fecha;
                existente.HoraEntrada = asistencia.HoraEntrada;
                existente.HoraSalida = asistencia.HoraSalida;
                existente.Justificada = asistencia.Justificada;
                existente.CreadoPor = asistencia.CreadoPor;

                contexto.SaveChanges();
                return true;
            }
            catch
            {
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

