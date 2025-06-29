using AccesoDatos.plugins;
using Gestion_Empleados.Context;
using Gestion_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Operations
{
    public class UsuarioDAO
    {
        public GestionEmpleados3Context context = new GestionEmpleados3Context();

        //GET
        public Usuario login(string usuario, string password)
        {
            string passwordHash = HashUtil.ObtenerMD5(password);

            var user = context.Usuarios.Where(a => a.Username.Equals(usuario) && a.PasswordHash.Equals(passwordHash)).FirstOrDefault();
            return user;
        }

        //GET
        public List<Usuario> listar()
        {
            var usuario = context.Usuarios.ToList<Usuario>();
            return usuario;
        }

        public Usuario listarId(int idUser)
        {
            var user = context.Usuarios.Where(a => a.IdUsuario == idUser).FirstOrDefault();
            return user;
        }

        //POST
        public bool registrar(Usuario newUsuario)
        {
            bool exist = context.Usuarios.Any(p => p.Username == newUsuario.Username);
            try
            {
                if (exist)
                {
                    return false;
                }
                else
                {
                    newUsuario.PasswordHash = HashUtil.ObtenerMD5(newUsuario.PasswordHash);
                    newUsuario.Activo = true;
                    context.Usuarios.Add(newUsuario);
                    context.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //PUT
        //Se actualiza el estado del usuario
        public bool actualizar(string usuario, string passworActual, string passwordNuevo)
        {
            try
            {
                var sesion = context.Usuarios.FirstOrDefault(e => e.Username == usuario);

                if (sesion == null)
                {
                    return false;
                }
                else
                {
                    sesion.PasswordHash = HashUtil.ObtenerMD5(passwordNuevo); ;
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

        //DELETE
        public bool eliminar(int id)
        {
            try
            {
                var delUser = listarId(id);

                if (delUser == null)
                {
                    return false;
                }
                else
                {
                    context.Usuarios.Remove(delUser);
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
