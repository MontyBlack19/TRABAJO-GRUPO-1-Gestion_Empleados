using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Asistencium
{
    public int IdAsistencia { get; set; }

    public int IdEmpleado { get; set; }

    public DateTime Fecha { get; set; }

    public TimeOnly  HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public bool? Justificada { get; set; }

    public int CreadoPor { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; } 

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
