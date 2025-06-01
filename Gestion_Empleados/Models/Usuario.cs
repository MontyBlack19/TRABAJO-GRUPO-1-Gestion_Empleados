using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual ICollection<HistorialEmpleado> HistorialEmpleados { get; set; } = new List<HistorialEmpleado>();

    public virtual ICollection<Justificacion> JustificacionAprobadoPorNavigations { get; set; } = new List<Justificacion>();

    public virtual ICollection<Justificacion> JustificacionCreadoPorNavigations { get; set; } = new List<Justificacion>();

    public virtual ICollection<Vacacione> VacacioneAprobadoPorNavigations { get; set; } = new List<Vacacione>();

    public virtual ICollection<Vacacione> VacacioneCreadoPorNavigations { get; set; } = new List<Vacacione>();
}
