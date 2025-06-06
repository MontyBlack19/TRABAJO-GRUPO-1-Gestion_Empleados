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
        public Usuario login(string user, string password)
        {   

                var usuario = context.Usuarios.Where(u => u.Username == user && u.PasswordHash == password).FirstOrDefault();
                return usuario;

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
        public bool insertar(string userName)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Username = userName;
                usuario.PasswordHash = "hashed_password_"+userName;
                usuario.Activo = true;

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        //PUT
        //Se actualiza el estado del usuario
        public bool actualizar(int id, bool activo)
        {
            try
            {
                var userId = listarId(id);

                if (userId == null)
                {
                    return false;
                }
                else
                {
                    userId.IdUsuario = id;
                    userId.Activo = activo;

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
