using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; }

    public string Telefono { get; set; }

    public DateTime FechaIngreso { get; set; }

    public int IdTipo { get; set; }

    public int IdDepartamento { get; set; }

    public int IdTurno { get; set; }

    public int IdSucursal { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Asistencium>? Asistencia { get; set; } = new List<Asistencium>();

    public virtual ICollection<HistorialEmpleado>? HistorialEmpleados { get; set; } = new List<HistorialEmpleado>();

    public virtual Departamento? IdDepartamentoNavigation { get; set; } = null!;

    public virtual Sucursal? IdSucursalNavigation { get; set; } = null!;

    public virtual TipoEmpleado? IdTipoNavigation { get; set; } = null!;

    public virtual Turno? IdTurnoNavigation { get; set; } = null!;

    public virtual ICollection<Justificacion>? Justificacions { get; set; } = new List<Justificacion>();

    public virtual ICollection<Vacacione>? Vacaciones { get; set; } = new List<Vacacione>();
}
