using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Empleados.Context;
using Gestion_Empleados.Models;

namespace AccesoDatos.Operaciones
{
    public class SucursalDAO
    {
        public GestionEmpleados3Context Contexto = new GestionEmpleados3Context();


        public List<Sucursal> seleccionarTodos()
        {
            var sucursal= Contexto.Sucursals.ToList<Sucursal>();
            return sucursal;
        }
        public Sucursal seleccionarSucursal(int id)
        {
            var sucursal = Contexto.Sucursals.Where(a => a.IdSucursal == id).FirstOrDefault();

            return sucursal;
        }
        public bool insertar(string nombre, string direccion, string telefono)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                sucursal.Nombre = nombre;
                sucursal.Direccion = direccion;
                sucursal.Telefono = telefono;
                

                Contexto.Sucursals.Add(sucursal);
                Contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool actualizar(int idsucursal, string nombre, string direccion, string telefono)
        {
            try
            {
                var sucursal = seleccionarSucursal(idsucursal);

                if (sucursal == null)
                {
                    return false;
                }
                else
                {
                    sucursal.IdSucursal = idsucursal;
                    sucursal.Nombre = nombre;
                   sucursal.Direccion = direccion;
                    sucursal.Telefono = telefono;                  

                    Contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int idSucursal)
        {
            try
            {
                var sucursal = seleccionarSucursal(idSucursal);

                if (sucursal == null)
                {
                    return false;
                }
                else
                {
                    Contexto.Sucursals.Remove(sucursal);
                    Contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    
        //public List<Sucursal> seleccionarSucursalEmpleados()
        //{
        //    var query = from e in Contexto.Empleados
        //                join s in Contexto.Sucursals on e.IdSucursal equals s.IdSucursal
        //                select new Sucursal
        //                {
        //                    Nombre = s.Nombre,
        //                    Empleados = e.Nombre
        //                };

        //    return query.ToList();

        //}
    }
}