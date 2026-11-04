using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class empleado
{
    public int id_empleado { get; set; }

    public string nombre { get; set; } = null!;

    public string? telefono { get; set; }

    public int id_rol { get; set; }

    public int id_turnos { get; set; }

    public virtual role id_rolNavigation { get; set; } = null!;

    public virtual turno id_turnosNavigation { get; set; } = null!;

    public virtual ICollection<ordene> ordenes { get; set; } = new List<ordene>();
}
