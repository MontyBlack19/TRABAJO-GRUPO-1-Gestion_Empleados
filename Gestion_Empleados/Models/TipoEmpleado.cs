using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class TipoEmpleado
{
    public int IdTipo { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Empleado>? Empleados { get; set; } = new List<Empleado>();
}
