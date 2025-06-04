using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Vacacione
{
    public int IdVacacion { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int AprobadoPor { get; set; }

    public DateTime FechaAprobacion { get; set; }

    public int CreadoPor { get; set; }

    public virtual Usuario? AprobadoPorNavigation { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; } = null!;

    public virtual Empleado? IdEmpleadoNavigation { get; set; } = null!;
}
