using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion_Empleados.Operations
{
    public class DepartamentoDAO
    {
        public GestionEmpleados3Context context = new GestionEmpleados3Context();

        public List<Departamento> listar()
        {
            var departamento = context.Departamentos.ToList<Departamento>();
            return departamento;
        }

        public Departamento listarId(int idDep)
        {
            var depa = context.Departamentos.Where(a => a.IdDepartamento == idDep).FirstOrDefault();
            return depa;
        }

        public bool insertar(string nombre)
        {
            try
            {
                Departamento departamento = new Departamento();
                departamento.Nombre = nombre;

                context.Departamentos.Add(departamento);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool actualizar(int id, string nombre) {
            try
            {
                var acdep = listarId(id);

                if (acdep == null)
                {
                    return false;
                }
                else
                {
                    acdep.IdDepartamento = id;
                    acdep.Nombre = nombre;

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
                var delalum = listarId(id);

                if (delalum == null)
                {
                    return false;
                }
                else
                {
                    context.Departamentos.Remove(delalum);
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

        public List<DepartamentoEmpleado> selecDepEmpleado()
        {
            var query = from e in context.Empleados
                        join te in context.TipoEmpleados on e.IdTipo equals te.IdTipo
                        join d in context.Departamentos on e.IdDepartamento equals d.IdDepartamento
                        select new DepartamentoEmpleado
                        {
                            nombreEmpleado = e.Nombre,
                            apellidoEmpleado = e.Apellido,
                            tipoEmpleado = te.NombreTipo,
                            nombreDepartamento = d.Nombre

                        };

            return query.ToList();
        }


        //Para el controller ----------------------------------------------

        public bool eliminarDepartamento(int id)
        {
            try
            {
                var dep = listarId(id);

                if (dep != null)
                {
                    var empleado = context.Empleados.Where(e => e.IdDepartamento == id);
                    foreach (Empleado e in empleado)
                    {
                        if (e.IdDepartamento == id)
                        {
                            e.IdDepartamento = 1;
                        }
                        else
                        {
                            eliminar(id);
                        }
                    }
                    context.SaveChanges();
                    context.Departamentos.RemoveRange(dep);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                return false;
            }
            
        }


    }
}
