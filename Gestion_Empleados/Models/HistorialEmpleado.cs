using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class HistorialEmpleado
{
    public int IdHistorial { get; set; }

    public int IdEmpleado { get; set; }

    public string CampoModificado { get; set; } = null!;

    public string? ValorAnterior { get; set; }

    public string? ValorNuevo { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int ModificadoPor { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; } 

    public virtual Usuario? ModificadoPorNavigation { get; set; } 
}
