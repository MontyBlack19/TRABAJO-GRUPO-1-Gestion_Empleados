using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Empleados.Models
{
    public class DepartamentoEmpleado
    {
        public string nombreEmpleado { get; set; }//Empleado
        public string apellidoEmpleado { get; set; }//Empleado
        public string tipoEmpleado { get; set; } //TipoEmpleado
        public string nombreDepartamento{ get; set; }//Departamento
    }
}
