using Gestion_Empleados.Models;
using Gestion_Empleados.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operaciones
{
    public class TurnoDAO
    {
        public GestionEmpleados3Context contexto = new GestionEmpleados3Context();


        public List<Turno> seleccionarTodos()
        {
            var turnos = contexto.Turnos.ToList<Turno>();
            return turnos;
        }

        public Turno seleccionarTurno(int id)
        {
            var turno = contexto.Turnos.Where(a => a.IdTurno == id).FirstOrDefault();

            return turno;
        }

        public bool insertar(string nombre, TimeOnly horaentrada, TimeOnly horasalida)
        {
            try
            {
                Turno turno = new Turno
                {
                    Nombre = nombre,
                    HoraEntrada = horaentrada,
                    HoraSalida = horasalida
                };

                contexto.Turnos.Add(turno);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar turno: " + ex.Message);
                return false;
            }
        }


        public bool actualizar(int id, string tipoturno, TimeOnly horaentrada, TimeOnly horasalida)
        {
            try
            {
                var turno = seleccionarTurno(id);

                if (turno == null)
                {
                    return false;
                }
                else
                {

                    turno.Nombre = tipoturno;
                    turno.HoraEntrada = horaentrada;
                    turno.HoraSalida = horasalida;

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
                var turno = seleccionarTurno(id);

                if (turno == null)
                {
                    return false;
                }
                else
                {
                    contexto.Turnos.Remove(turno);
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
