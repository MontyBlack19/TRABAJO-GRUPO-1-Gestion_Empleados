using System;
using System.Collections.Generic;

namespace Gestion_Empleados.Models;

public partial class Bitacora
{
    public int IdLog { get; set; }

    public string Accion { get; set; } = null!;

    public string? TablaAfectada { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
