using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly HoraEntrada { get; set; }

    public TimeOnly HoraSalida { get; set; }

    public virtual ICollection<Empleado>? Empleados { get; set; } = new List<Empleado>();
}
