using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Empleado>? Empleados { get; set; } = new List<Empleado>();
}
