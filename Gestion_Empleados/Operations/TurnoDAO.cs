using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operations
{
    public class TurnoDAO
    {
        private readonly GestionEmpleados3Context contexto = new GestionEmpleados3Context();

        public List<Turno> SeleccionarTodos()
        {
            return contexto.Turnos.ToList();
        }

        public Turno SeleccionarPorId(int id)
        {
            return contexto.Turnos.FirstOrDefault(t => t.IdTurno == id);
        }

        public bool Insertar(Turno turno)
        {
            try
            {
                contexto.Turnos.Add(turno);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Turno turno)
        {
            try
            {
                var existente = SeleccionarPorId(turno.IdTurno);
                if (existente == null) return false;

                existente.Nombre = turno.Nombre;
                existente.HoraEntrada = turno.HoraEntrada;
                existente.HoraSalida = turno.HoraSalida;

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
                var turno = SeleccionarPorId(id);
                if (turno == null) return false;

                contexto.Turnos.Remove(turno);
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
